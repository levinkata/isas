using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class PremiumsController : Controller
    {
        private readonly InsurerDbContext _context;

        public PremiumsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Premiums
        public async Task<IActionResult> Index(Guid productId, Guid clientId, Guid policyId)
        {
            var premiums = await (from p in _context.Premiums
                                .Include(p => p.Policy)
                                .Include(r => r.Risk)
                                .Include(t => t.PremiumType)
                                .Include(r => r.Receivable)
                                    .ThenInclude(p => p.PaymentType)
                                .AsNoTracking()
                                where p.PolicyID == policyId
                                orderby p.PremiumDate
                                select p).ToListAsync();
            
            PremiumsViewModel viewModel = new PremiumsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Premiums = premiums
            };
            return View(viewModel);
        }

        // GET: Premiums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.SingleOrDefaultAsync(m => m.ID == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // GET: Premiums/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {

            Receivable receivable = new Receivable
            {
                ReceivableDate = DateTime.Now
            };

            Premium premium = new Premium
            {
                PremiumDate = DateTime.Now
            };

            PremiumViewModel viewModel = new PremiumViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Receivable = receivable,
                Premium = premium,
                PaymentTypeList = new SelectList(await _context.PaymentTypes.AsNoTracking().ToListAsync(),
                                                    "ID", "Name"),
                PremiumTypeList = new SelectList(await _context.PremiumTypes.AsNoTracking().ToListAsync(),
                                                    "ID", "Name")
            };
            return View(viewModel);
        }

        // POST: Premiums/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed(PremiumViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productId = viewModel.ProductID;

                    Receivable receivable = viewModel.Receivable;
                    receivable.ID = Guid.NewGuid();
                    receivable.ProductID = productId;
                    _context.Add(receivable);
                    await _context.SaveChangesAsync();

                    var receivableId = receivable.ID;
                    var policyId = viewModel.PolicyID;

                    //  Collect RiskItemID using PolicyID and RiskID
                    //  Split the premium if more than 1 RiskItemIDs
                    object[,] riskItemPremiums = GetRiskItems(policyId);

                    Premium premium = viewModel.Premium;
                    var availablePremium = premium.Amount;
                    var riskId = 0;

                    if (riskItemPremiums.Length > 0)
                    {
                        for (int i = 0; i < riskItemPremiums.GetUpperBound(0) + 1 ; i++)
                        {
                            if (riskId != int.Parse(riskItemPremiums[i, 0].ToString()))
                            {
                                riskId = int.Parse(riskItemPremiums[i, 0].ToString());
                            }

                            premium.ID = Guid.NewGuid();
                            premium.ReceivableID = receivableId;
                            premium.PolicyID = policyId;
                            premium.RiskID = riskId;
                            premium.RiskItemID = Guid.Parse(riskItemPremiums[i, 1].ToString());

                            //  Split the Premium Amount if more than one risk item
                            var riskitempremium = decimal.Parse(riskItemPremiums[i, 2].ToString());
                            var balancePremium = availablePremium - riskitempremium;

                            if (balancePremium > -1)
                            {
                                premium.Amount = riskitempremium;
                                availablePremium = balancePremium;
                            }
                            else
                            {
                                premium.Amount = availablePremium;
                                availablePremium = 0;
                            }

                            //  Calculate Policy Fee, Commission and Admin Fee
                            //  using currentproductId and premium amount
                            List<decimal> BrokerCharges = GetBrokerCharges(productId, riskId, premium.Amount);
                            premium.PolicyFee = BrokerCharges[0];
                            premium.Commission = BrokerCharges[1];
                            premium.AdminFee = BrokerCharges[2];
                            _context.Add(premium);
                            await _context.SaveChangesAsync();
                        }
                    }

                    //  Update the policy table with next premium due date based on the policy
                    //  frequency
                    var premiumDate = premium.PremiumDate;
                    UpdatePremiumDueDate(policyId, premiumDate);

                    return RedirectToAction("Index", new {
                        productId = viewModel.ProductID, clientId = viewModel.ClientID, policyId = viewModel.PolicyID });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;
                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }
            viewModel.PaymentTypeList = new SelectList(await _context.PaymentTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                                    "ID", "Name", viewModel.Receivable.PaymentTypeID);
            viewModel.PremiumTypeList = new SelectList(await _context.PremiumTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                                    "ID", "Name", viewModel.Premium.PremiumTypeID);
            return View(viewModel);
        }

        // GET: Premiums/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            Premium premium = await _context.Premiums.SingleOrDefaultAsync(m => m.ID == Id);

            PremiumViewModel viewModel = new PremiumViewModel
            {
                Premium = premium,
                PremiumTypeList = new SelectList(await _context.PremiumTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                                    "ID", "Name", premium.PremiumTypeID)
            };
            return View(viewModel);
        }

        // POST: Premiums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PremiumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Premium premium = new Premium();
                    premium = viewModel.Premium;

                    //  Calculate Policy Fee, Commission and Admin Fee using currentproductId
                    List<decimal> BrokerCharges = GetBrokerCharges(viewModel.ProductID, premium.RiskID, premium.Amount);
                    premium.PolicyFee = BrokerCharges[0];
                    premium.Commission = BrokerCharges[1];
                    premium.AdminFee = BrokerCharges[2];

                    _context.Update(premium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    var errorMsg = ex.InnerException.Message.ToString();

                    viewModel.ErrMsg = errorMsg;
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }
                return RedirectToAction("Index", new
                {
                    productId = viewModel.ProductID,
                    clientId = viewModel.ClientID,
                    policyId = viewModel.PolicyID
                });
            }
            viewModel.PremiumTypeList = new SelectList(await _context.PremiumTypes.AsNoTracking().OrderBy(p => p.Name).ToListAsync(),
                                    "ID", "Name", viewModel.Premium.PremiumTypeID);
            return View(viewModel);
        }

        // GET: Premiums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.SingleOrDefaultAsync(m => m.ID == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // POST: Premiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var premium = await _context.Premiums.SingleOrDefaultAsync(m => m.ID == id);
            _context.Premiums.Remove(premium);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Products/BulkPremium
        public async Task<IActionResult> BulkPremium(Guid loadFormatId, UploadFileTypes uploadFileType, string delimiter)
        {
            UpLoadPremiumViewModel viewModel = new UpLoadPremiumViewModel
            {
                LoadFormatID = loadFormatId,
                UploadFileType = uploadFileType,
                Delimiter = delimiter,
                TableName = "Premium",
                ReceivableDate = DateTime.Now,
                PaymentTypeList = new SelectList(await _context.PaymentTypes.ToListAsync(), "ID", "Name", await _context.PaymentTypes.FirstOrDefaultAsync()),
                PremiumTypeList = new SelectList(await _context.PremiumTypes.ToListAsync(), "ID", "Name", await _context.PremiumTypes.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Products/BulkPremium
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkPremium(UpLoadPremiumViewModel viewModel)
        {
            Guid currentproductId = Guid.Parse(HttpContext.Session.GetString("ProductID"));
            Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int startRow = viewModel.StartRow;

            string IDNumberPos = string.Empty;
            string PremiumDatePos = string.Empty;
            string AmountPos = string.Empty;

            //  Uncomment/comment the below if residue data was not deleted in the ClientTemp table.

            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM PremiumTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var formattypes = _context.FormatTypes
                                .Where(l => l.LoadFormatID == viewModel.LoadFormatID &&
                                l.TableName == viewModel.TableName)
                                .ToList();

            foreach (var row in formattypes)
            {
                switch (row.FieldName)
                {
                    case "IDNumber":
                        IDNumberPos = row.Position;
                        break;
                    case "PremiumDate":
                        PremiumDatePos = row.Position;
                        break;
                    case "Amount":
                        AmountPos = row.Position;
                        break;
                    case "default":
                        break;
                }
            }

            IFormFile uploadFile = viewModel.UpLoadFile;
            IList<PremiumTemp> premiumtemps = new List<PremiumTemp>();

            using (MemoryStream ms = new MemoryStream())
            {
                await uploadFile.CopyToAsync(ms);
                try
                {
                    if (viewModel.UploadFileType == UploadFileTypes.Excel)
                    {
                        using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(ms))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                            int rowCount = worksheet.Dimension.Rows;

                            for (int row = startRow; row <= rowCount; row++)
                            {
                                PremiumTemp premiumtemp = new PremiumTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PremiumTypeID = viewModel.PremiumTypeID,
                                    Reference = viewModel.Reference,
                                    ReceivableDate = viewModel.ReceivableDate,
                                    PaymentTypeID = viewModel.PaymentTypeID,
                                    PaymentAmount = viewModel.PaymentAmount,
                                    BatchNumber = viewModel.BatchNumber
                                };

                                if (worksheet.Cells[IDNumberPos + row].Value != null && IDNumberPos != null)
                                    premiumtemp.IDNumber = worksheet.Cells[IDNumberPos + row].Value.ToString().Trim();
                                else
                                    break;

                                if (worksheet.Cells[PremiumDatePos + row].Value != null && PremiumDatePos != null)
                                {
                                    var premiumdate = worksheet.Cells[PremiumDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(premiumdate);
                                    premiumtemp.PremiumDate = dt;
                                }
                                else
                                    premiumtemp.PremiumDate = viewModel.PremiumDate;

                                if (worksheet.Cells[AmountPos + row].Value != null && AmountPos != null)
                                    premiumtemp.Amount = decimal.Parse(worksheet.Cells[AmountPos + row].Value.ToString().Trim());
                                else
                                    premiumtemp.Amount = 0;

                                premiumtemps.Add(premiumtemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.CSV)
                    {
                        char[] delimiter = viewModel.Delimiter.ToCharArray(); // Get Delimiter

                        using (StreamReader sr = new StreamReader(uploadFile.OpenReadStream()))
                        {
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (startRow > 0)
                                for (int i = 0; i < startRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                PremiumTemp premiumtemp = new PremiumTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PremiumTypeID = viewModel.PremiumTypeID
                                };

                                string[] cols = line.Split(delimiter);

                                if (cols[int.Parse(IDNumberPos)] != null && IDNumberPos != null)
                                    premiumtemp.IDNumber = cols[int.Parse(IDNumberPos)];
                                else
                                    break;

                                if (cols[int.Parse(PremiumDatePos)] != null && PremiumDatePos != null)
                                {
                                    var premiumdate = cols[int.Parse(PremiumDatePos)];
                                    DateTime dt = Convert.ToDateTime(premiumdate);
                                    premiumtemp.PremiumDate = dt;
                                }
                                else
                                    premiumtemp.PremiumDate = viewModel.PremiumDate;

                                if (cols[int.Parse(AmountPos)] != null && AmountPos != null)
                                    premiumtemp.Amount = decimal.Parse(cols[int.Parse(AmountPos)]);
                                else
                                    premiumtemp.Amount = 0;

                                premiumtemps.Add(premiumtemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.FixedLengthDelimited)
                    {
                        int IDNumberLen = 0;
                        int PremiumDateLen = 0;
                        int AmountLen = 0;

                        foreach (var row in formattypes)
                        {
                            switch (row.FieldName)
                            {
                                case "IDNumber":
                                    IDNumberLen = row.ColumnLength;
                                    break;
                                case "PremiumDate":
                                    PremiumDateLen = row.ColumnLength;
                                    break;
                                case "Amount":
                                    AmountLen = row.ColumnLength;
                                    break;
                                case "default":
                                    break;
                            }
                        }

                        using (StreamReader sr = new StreamReader(uploadFile.OpenReadStream()))
                        {
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (startRow > 0)
                                for (int i = 0; i < startRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                PremiumTemp premiumtemp = new PremiumTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PremiumTypeID = viewModel.PremiumTypeID
                                };

                                if (line.Substring(int.Parse(IDNumberPos), IDNumberLen) != null && IDNumberPos != null)
                                    premiumtemp.IDNumber = line.Substring(int.Parse(IDNumberPos), IDNumberLen);
                                else
                                    break;

                                if (line.Substring(int.Parse(PremiumDatePos), PremiumDateLen) != null && PremiumDatePos != null)
                                {
                                    var premiumdate = line.Substring(int.Parse(PremiumDatePos), PremiumDateLen);
                                    DateTime dt = Convert.ToDateTime(premiumdate);
                                    premiumtemp.PremiumDate = dt;
                                }
                                else
                                    premiumtemp.PremiumDate = viewModel.PremiumDate;

                                if (line.Substring(int.Parse(AmountPos), AmountLen) != null && AmountPos != null)
                                    premiumtemp.Amount = decimal.Parse(line.Substring(int.Parse(AmountPos), AmountLen));
                                else
                                    premiumtemp.Amount = 0;

                                premiumtemps.Add(premiumtemp);
                            }
                        }
                    }
                    ms.Flush();
                    ViewData["Message"] = "The records are all the data that has been successfully uploaded from the input file." + "\n" +
                                          "You can proceed to load them to the database.";

                    foreach (PremiumTemp p in premiumtemps)
                    {
                        _context.PremiumTemps.Add(p);
                    }
                    _context.SaveChanges();

                    return RedirectToAction("LoadPremiums", new
                    {
                        userId = currentUserId,
                        productId = currentproductId
                    });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Some error occured while exporting. ", ex.Message);
                }
                ms.Flush();
            }
            viewModel.UpLoadFile = uploadFile;
            viewModel.PaymentTypeList = new SelectList(await _context.PaymentTypes.ToListAsync(), "ID", "Name", viewModel.PaymentTypeID);
            viewModel.PremiumTypeList = new SelectList(await _context.PremiumTypes.ToListAsync(), "ID", "Name", viewModel.PremiumTypeID);
            return View(viewModel);
        }

        // GET: Products/LoadPremiums
        public async Task<IActionResult> LoadPremiums(Guid userId, Guid productId, int riskId)
        {
            var premiumtemps = await (from p in _context.PremiumTemps
                                   .Where(u => u.UserID == userId)
                                   .Include(p => p.PremiumType)
                                   .OrderBy(i => i.IDNumber)
                                     select p).ToListAsync();

        var premiumTotal = premiumtemps.Sum(p => p.Amount);

            PremiumTempsViewModel viewModel = new PremiumTempsViewModel
            {
                PremiumTemps = premiumtemps,
                ProductID = productId,
                UserID = userId,
                RiskID = riskId,
                PremiumTotal = premiumTotal,
                Reference = _context.PremiumTemps.FirstOrDefault().Reference,
                ReceivableDate = _context.PremiumTemps.FirstOrDefault().ReceivableDate,
                PaymentTypeID = _context.PremiumTemps.FirstOrDefault().PaymentTypeID,
                PaymentAmount = _context.PremiumTemps.FirstOrDefault().PaymentAmount,
                BatchNumber = _context.PremiumTemps.FirstOrDefault().BatchNumber
            };

            return View(viewModel);
        }

        // GET: Products/LoadPremiumsConfirmed
        [HttpPost, ActionName("LoadPremiums")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadPremiumsConfirmed(PremiumTempsViewModel viewModel)
        {
            var currentUserId = viewModel.UserID;
            var currentProductId = viewModel.ProductID;
            var currentRiskId = viewModel.RiskID;

            BulkHandles bulkhandle = new BulkHandles();

            int newbulkhandle = bulkhandle.GetBulkHandle(_context);

            var premiumtemps = from p in _context.PremiumTemps
                                   .Where(u => u.UserID == currentUserId)
                                   .Include(p => p.PremiumType)
                                   .OrderBy(i => i.IDNumber)
                              select p;

            int recCount = premiumtemps.Count();

            var recParam = new object[] { Guid.NewGuid(), currentProductId, viewModel.Reference, viewModel.ReceivableDate, viewModel.PaymentTypeID,
                                        viewModel.PaymentAmount, viewModel.BatchNumber, DateTime.Now, currentUserId, null, null };

            await _context.Database.ExecuteSqlCommandAsync(
                        "INSERT INTO Receivable(ID, ProductID, Reference, ReceivableDate, PaymentTypeID, Amount, BatchNumber, " +
                        "DateAdded, AddedBy, DateModified, ModifiedBy) " +
                        "Values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})",
                        parameters: recParam);

            Guid receivableId = GetReceivableId(viewModel.Reference);

            foreach (var p in premiumtemps)
            {
                if (PolicyExists(p.IDNumber))
                {
                    var policyId = GetPolicyId(p.IDNumber);

                    //  Collect RiskItemID using PolicyID and RiskID
                    //  Split the premium if more than 1 RiskItemIDs
                    object[,] riskItemPremium = GetRiskItem(policyId, currentRiskId);
                    var availablePremium = p.Amount;

                    if (riskItemPremium.Length > 0)
                    {
                        for (int i = 0; i < riskItemPremium.GetUpperBound(0) + 1; i++)
                        {
                            var currentRiskItemId = Guid.Parse(riskItemPremium[i, 0].ToString());

                            //  Split the Premium Amount if more than one risk item
                            var riskitempremium = decimal.Parse(riskItemPremium[i, 1].ToString());
                            var balancePremium = availablePremium - riskitempremium;

                            if (balancePremium > -1)
                            {
                                p.Amount = riskitempremium;
                                availablePremium = balancePremium;
                            }
                            else
                            {
                                p.Amount = availablePremium;
                                availablePremium = 0;
                            }

                            //  Calculate Policy Fee, Commission and Admin Fee
                            //  using currentproductId and premium amount
                            List<decimal> BrokerCharges = GetBrokerCharges(viewModel.ProductID, currentRiskId, p.Amount);
                            p.PolicyFee = BrokerCharges[0];
                            p.Commission = BrokerCharges[1];
                            p.AdminFee = BrokerCharges[2];

                            var premiumParams = new object[] { Guid.NewGuid(), policyId, p.RiskID, currentRiskItemId, p.PremiumDate, p.PremiumTypeID,
                                        p.Amount, p.PolicyFee, p.Commission, p.AdminFee, receivableId, newbulkhandle, DateTime.Now, currentUserId, null, null };

                            await _context.Database.ExecuteSqlCommandAsync(
                                                    "INSERT INTO Premium(ID, PolicyID, RiskID, RiskItemID, PremiumDate, PremiumTypeID, Amount, PolicyFee, " +
                                                    "Commission, AdminFee, ReceivableID, " +
                                                    "BulkHandle, DateAdded, AddedBy, DateModified, ModifiedBy) " +
                                                    "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})",
                                                    parameters: premiumParams);
                        }
                    }
                }
                else
                {
                    //  Generate a log file and ask user to load on Client and Policy before loading premiums again.
                }
            }

            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM PremiumTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var bulkParams = new object[] { newbulkhandle, "Premium", DateTime.Now, recCount, DateTime.Now, currentUserId };

            await _context.Database.ExecuteSqlCommandAsync(
                                    "INSERT INTO BulkHandleGenerator(BulkNumber, TableName, BulkDate, RecordCount, DateAdded, AddedBy) " +
                                    "Values ({0}, {1}, {2}, {3}, {4}, {5})",
                                    parameters: bulkParams);

            return RedirectToAction("ProductClients", "Products", new { productId = currentProductId });
        }

        private bool PolicyExists(string IDNumber)
        {
            Guid clientId = _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
            return _context.Policies.Any(c => c.ClientID == clientId);
        }

        protected void UpdatePremiumDueDate(Guid policyId, DateTime premiumDate)
        {
            var policy = _context.Policies
                .Include(f => f.PolicyFrequency)
                .SingleOrDefault(p => p.ID == policyId);

            var divisor = policy.PolicyFrequency.Divisor;
            var currentDueDate = policy.PremiumDueDate;
            var interval = 12 / divisor;
            var nextDueDate = currentDueDate.AddMonths(interval);
            var policyParams = new object[] { policyId, nextDueDate };

            _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Policy SET PremiumDueDate = {1} WHERE ID = {0})",
                                    parameters: policyParams);
        }

        private Guid GetPolicyId(string IDNumber)
        {
            Guid clientId = _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
            return _context.Policies.Single(c => c.ClientID == clientId).ID;
        }

        private object[,] GetRiskItem(Guid policyId, int riskId)
        {
            object[,] riskItemPremiums = new object[0, 2];

            switch (riskId)
            {
                case 1:
                    var allrisks = _context.AllRisks.Where(p => p.PolicyID == policyId).ToList();
                    if (allrisks != null)
                    {
                        riskItemPremiums = new object[allrisks.Count(), 2];
                        int i = 0;
                        foreach (AllRisk item in allrisks)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 2:
                    var commercials = _context.Commercials.Where(p => p.PolicyID == policyId).ToList();
                    if (commercials != null)
                    {
                        riskItemPremiums = new object[commercials.Count(), 2];
                        int i = 0;
                        foreach (Commercial item in commercials)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 3:
                    var contents = _context.Contents.Where(p => p.PolicyID == policyId).ToList();
                    if (contents != null)
                    {
                        riskItemPremiums = new object[contents.Count(), 2];
                        int i = 0;
                        foreach (Content item in contents)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 4:
                    var loans = _context.Loans.Where(p => p.PolicyID == policyId).ToList();
                    if (loans != null)
                    {
                        riskItemPremiums = new object[loans.Count(), 2];
                        int i = 0;
                        foreach (Loan item in loans)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 5:
                    var motors = _context.Motors.Where(p => p.PolicyID == policyId).ToList();
                    if (motors != null)
                    {
                        riskItemPremiums = new object[motors.Count(), 2];
                        int i = 0;
                        foreach (Motor item in motors)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 6:
                    var properties = _context.Properties.Where(p => p.PolicyID == policyId).ToList();
                    if (properties != null)
                    {
                        riskItemPremiums = new object[properties.Count(), 2];
                        int i = 0;
                        foreach (Property item in properties)
                        {
                            riskItemPremiums[i, 0] = item.ID;
                            riskItemPremiums[i, 1] = item.Premium;
                            i++;
                        }
                    }
                    break;
                case 7:
                    break;
            }
            return riskItemPremiums;
        }

        private object[,] GetRiskItems(Guid policyId)
        {
            var allrisks = _context.AllRisks.Where(p => p.PolicyID == policyId).ToList();
            var commercials = _context.Commercials.Where(p => p.PolicyID == policyId).ToList();
            var contents = _context.Contents.Where(p => p.PolicyID == policyId).ToList();
            var loans = _context.Loans.Where(p => p.PolicyID == policyId).ToList();
            var motors = _context.Motors.Where(p => p.PolicyID == policyId).ToList();
            var properties = _context.Properties.Where(p => p.PolicyID == policyId).ToList();

            var arraySize = allrisks.Count + commercials.Count + contents.Count + loans.Count + motors.Count + properties.Count;

            object[,] riskItemPremiums = new object[arraySize, 3];
            int i = 0;

            if (allrisks != null)
            {
                foreach (AllRisk item in allrisks)
                {
                    riskItemPremiums[i, 0] = 1;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            if (commercials != null)
            {
                foreach (Commercial item in commercials)
                {
                    riskItemPremiums[i, 0] = 2;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            if (contents != null)
            {
                foreach (Content item in contents)
                {
                    riskItemPremiums[i, 0] = 3;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            if (loans != null)
            {
                foreach (Loan item in loans)
                {
                    riskItemPremiums[i, 0] = 4;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            if (motors != null)
            {
                foreach (Motor item in motors)
                {
                    riskItemPremiums[i, 0] = 5;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            if (properties != null)
            {
                foreach (Property item in properties)
                {
                    riskItemPremiums[i, 0] = 6;
                    riskItemPremiums[i, 1] = item.ID;
                    riskItemPremiums[i, 2] = item.Premium;
                    i++;
                }
            };

            return riskItemPremiums;
        }

        private List<decimal> GetBrokerCharges(Guid productId, int riskId, decimal premium)
        {
            List<decimal> charges = new List<decimal>();
            decimal calculatedPolicyFee = 0;
            decimal calculatedCommission = 0;
            decimal calculatedAdminFee = 0;

            var productrisk = _context.ProductRisks
                            .SingleOrDefault(r => r.ProductID == productId && r.RiskID == riskId);

            if (productrisk != null)
            {
                var policyFee = productrisk.PolicyFee;
                var commission = productrisk.Commission;
                var adminFee = productrisk.AdminFee;

                calculatedPolicyFee = (policyFee * premium)/100;
                calculatedCommission = (commission * premium)/ 100;
                calculatedAdminFee = (adminFee * premium)/ 100;
            }
            charges.Add(calculatedPolicyFee);
            charges.Add(calculatedCommission);
            charges.Add(calculatedAdminFee);
            return charges;
        }

        private Guid GetReceivableId(string reference)
        {
            return _context.Receivables.Single(r => r.Reference == reference).ID;
        }
        private bool PremiumExists(Guid id)
        {
            return _context.Premiums.Any(e => e.ID == id);
        }
    }
}
