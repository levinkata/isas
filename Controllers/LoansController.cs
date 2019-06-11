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
    public class LoansController : Controller
    {
        private readonly InsurerDbContext _context;

        public LoansController(InsurerDbContext context)
        {
            _context = context;    
        }
        
        // GET: Loans
        public async Task<IActionResult> Index(Guid policyId)
        {
            var loans = _context.Loans
                .Include(l => l.Component)
                .Include(l => l.Policy)
                .OrderBy(c => c.Component.Name)
                .Where(p => p.PolicyID == policyId);

            return View(await loans.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.SingleOrDefaultAsync(m => m.ID == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            Loan loan = new Loan
            {
                LoanDate = DateTime.Now
            };

            LoanViewModel viewModel = new LoanViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Loan = loan,
                ComponentList = new SelectList(await _context.Components.ToListAsync(), "ID", "Name", await _context.Components.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Loans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Loan loan = viewModel.Loan;
                loan.ID = Guid.NewGuid();
                loan.PolicyID = viewModel.PolicyID;
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction("PolicyRisks", "Policies",
                    new { productId = viewModel.ProductID, clientId = viewModel.ClientID, policyid = viewModel.PolicyID });
            }
            viewModel.ComponentList = new SelectList(await _context.Components.ToListAsync(), "ID", "Name", viewModel.Loan.ComponentID);
            return View(viewModel);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.SingleOrDefaultAsync(m => m.ID == id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewData["ComponentID"] = new SelectList(_context.Components, "ID", "Name", loan.ComponentID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", loan.PolicyID);
            return View(loan);
        }

        // POST: Loans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,AccountNumber,ComponentID,EndDate,LoanDate,PolicyID,Premium,Rate,SettlementDate,StartDate,Term,Value")] Loan loan)
        {
            if (id != loan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ComponentID"] = new SelectList(_context.Components, "ID", "Name", loan.ComponentID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", loan.PolicyID);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.SingleOrDefaultAsync(m => m.ID == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(m => m.ID == id);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Loans/BulkLoan
        public async Task<IActionResult> BulkLoan(Guid loadFormatId, UploadFileTypes uploadFileType, string delimiter)
        {
            UpLoadLoanViewModel viewModel = new UpLoadLoanViewModel
            {
                LoadFormatID = loadFormatId,
                UploadFileType = uploadFileType,
                Delimiter = delimiter,
                TableName = "Loan",
                ComponentList = new SelectList(await _context.Components.ToListAsync(), "ID", "Name", await _context.Components.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Loans/BulkLoan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkLoan(UpLoadLoanViewModel viewModel)
        {
            Guid currentproductId = Guid.Parse(HttpContext.Session.GetString("ProductID"));
            Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int startRow = viewModel.StartRow;

            string IDNumberPos = string.Empty;
            string AccountNumberPos = string.Empty;
            string TermPos = string.Empty;
            string RatePos = string.Empty;
            string LoanDatePos = string.Empty;
            string ValuePos = string.Empty;
            string PremiumPos = string.Empty;
            string SettlementDatePos = string.Empty;

        //  Uncomment/comment the below if residue data was not deleted in the ClientTemp table.

        Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM LoanTemp WHERE UserID = {0}",
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
                    case "AccountNumber":
                        AccountNumberPos = row.Position;
                        break;
                    case "Term":
                        TermPos = row.Position;
                        break;
                    case "Rate":
                        RatePos = row.Position;
                        break;
                    case "LoanDate":
                        LoanDatePos = row.Position;
                        break;
                    case "Value":
                        ValuePos = row.Position;
                        break;
                    case "Premium":
                        PremiumPos = row.Position;
                        break;
                    case "SettlementDate":
                        SettlementDatePos = row.Position;
                        break;
                    case "default":
                        break;
                }
            }

            IFormFile uploadFile = viewModel.UpLoadFile;
            IList<LoanTemp> loantemps = new List<LoanTemp>();

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
                                LoanTemp loantemp = new LoanTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    ComponentID = viewModel.ComponentID
                                };

                                if (worksheet.Cells[IDNumberPos + row].Value != null && IDNumberPos != null)
                                    loantemp.IDNumber = worksheet.Cells[IDNumberPos + row].Value.ToString().Trim();
                                else
                                    break;

                                if (worksheet.Cells[AccountNumberPos + row].Value != null && AccountNumberPos != null)
                                    loantemp.AccountNumber = worksheet.Cells[AccountNumberPos + row].Value.ToString().Trim();
                                else
                                    loantemp.AccountNumber = string.Empty;

                                if (worksheet.Cells[TermPos + row].Value != null && TermPos != null)
                                    loantemp.Term = decimal.Parse(worksheet.Cells[TermPos + row].Value.ToString().Trim());
                                else
                                    loantemp.Term = 0;

                                if (worksheet.Cells[RatePos + row].Value != null && RatePos != null)
                                    loantemp.Rate = decimal.Parse(worksheet.Cells[RatePos + row].Value.ToString().Trim());
                                else
                                    loantemp.Rate = 0;

                                if (worksheet.Cells[LoanDatePos + row].Value != null && LoanDatePos != null)
                                {
                                    var loandate = worksheet.Cells[LoanDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(loandate);
                                    loantemp.LoanDate = dt;
                                }
                                else
                                    loantemp.LoanDate = null;

                                if (worksheet.Cells[ValuePos + row].Value != null && ValuePos != null)
                                    loantemp.Value = decimal.Parse(worksheet.Cells[ValuePos + row].Value.ToString().Trim());
                                else
                                    loantemp.Value = 0;

                                if (worksheet.Cells[PremiumPos + row].Value != null && PremiumPos != null)
                                    loantemp.Premium = decimal.Parse(worksheet.Cells[PremiumPos + row].Value.ToString().Trim());
                                else
                                    loantemp.Premium = 0;

                                if (worksheet.Cells[SettlementDatePos + row].Value != null && SettlementDatePos != null)
                                {
                                    var settlementdate = worksheet.Cells[SettlementDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(settlementdate);
                                    loantemp.SettlementDate = dt;
                                }
                                else
                                    loantemp.SettlementDate = loantemp.LoanDate.Value.AddMonths(int.Parse(loantemp.Term.ToString())); ;

                                loantemps.Add(loantemp);
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
                                LoanTemp loantemp = new LoanTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    ComponentID = viewModel.ComponentID
                                };

                                string[] cols = line.Split(delimiter);

                                if (cols[int.Parse(IDNumberPos)] != null && IDNumberPos != null)
                                    loantemp.IDNumber = cols[int.Parse(IDNumberPos)];
                                else
                                    break;

                                if (cols[int.Parse(AccountNumberPos)] != null && AccountNumberPos != null)
                                    loantemp.AccountNumber = cols[int.Parse(AccountNumberPos)];
                                else
                                    loantemp.AccountNumber = string.Empty;

                                if (cols[int.Parse(TermPos)] != null && TermPos != null)
                                    loantemp.Term = decimal.Parse(cols[int.Parse(TermPos)]);
                                else
                                    loantemp.Term = 0;

                                if (cols[int.Parse(RatePos)] != null && RatePos != null)
                                    loantemp.Rate = decimal.Parse(cols[int.Parse(RatePos)]);
                                else
                                    loantemp.Rate = 0;

                                if (cols[int.Parse(LoanDatePos)] != null && LoanDatePos != null)
                                {
                                    var loandate = cols[int.Parse(LoanDatePos)];
                                    DateTime dt = Convert.ToDateTime(loandate);
                                    loantemp.LoanDate = dt;
                                }
                                else
                                    loantemp.LoanDate = null;

                                if (cols[int.Parse(ValuePos)] != null && ValuePos != null)
                                    loantemp.Value = decimal.Parse(cols[int.Parse(ValuePos)]);
                                else
                                    loantemp.Value = 0;

                                if (cols[int.Parse(PremiumPos)] != null && PremiumPos != null)
                                    loantemp.Premium = decimal.Parse(cols[int.Parse(PremiumPos)]);
                                else
                                    loantemp.Premium = 0;

                                if (cols[int.Parse(SettlementDatePos)] != null && SettlementDatePos != null)
                                {
                                    var settlementdate = cols[int.Parse(SettlementDatePos)];
                                    DateTime dt = Convert.ToDateTime(settlementdate);
                                    loantemp.SettlementDate = dt;
                                }
                                else
                                    loantemp.SettlementDate = loantemp.LoanDate.Value.AddMonths(int.Parse(loantemp.Term.ToString()));

                                loantemps.Add(loantemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.FixedLengthDelimited)
                    {
                        int IDNumberLen = 0;
                        int AccountNumberLen = 0;
                        int TermLen = 0;
                        int RateLen = 0;
                        int LoanDateLen = 0;
                        int ValueLen = 0;
                        int PremiumLen = 0;
                        int SettlementDateLen = 0;

                        foreach (var row in formattypes)
                        {
                            switch (row.FieldName)
                            {
                                case "IDNumber":
                                    IDNumberLen = row.ColumnLength;
                                    break;
                                case "AccountNumber":
                                    AccountNumberLen = row.ColumnLength;
                                    break;
                                case "Term":
                                    TermLen = row.ColumnLength;
                                    break;
                                case "Rate":
                                    RateLen = row.ColumnLength;
                                    break;
                                case "LoanDate":
                                    LoanDateLen = row.ColumnLength;
                                    break;
                                case "Value":
                                    ValueLen = row.ColumnLength;
                                    break;
                                case "Premium":
                                    PremiumLen = row.ColumnLength;
                                    break;
                                case "SettlementDate":
                                    SettlementDateLen = row.ColumnLength;
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
                                LoanTemp loantemp = new LoanTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    ComponentID = viewModel.ComponentID
                                };

                                if (line.Substring(int.Parse(IDNumberPos), IDNumberLen) != null && IDNumberPos != null)
                                    loantemp.IDNumber = line.Substring(int.Parse(IDNumberPos), IDNumberLen);
                                else
                                    break;

                                if (line.Substring(int.Parse(AccountNumberPos), AccountNumberLen) != null && AccountNumberPos != null)
                                    loantemp.AccountNumber = line.Substring(int.Parse(AccountNumberPos), AccountNumberLen);
                                else
                                    loantemp.AccountNumber = string.Empty;

                                if (line.Substring(int.Parse(TermPos), TermLen) != null && TermPos != null)
                                    loantemp.Term = int.Parse(line.Substring(int.Parse(TermPos), TermLen));
                                else
                                    loantemp.Term = 0;

                                if (line.Substring(int.Parse(RatePos), RateLen) != null && RatePos != null)
                                    loantemp.Rate = decimal.Parse(line.Substring(int.Parse(RatePos), RateLen));
                                else
                                    loantemp.Rate = 0;

                                if (line.Substring(int.Parse(LoanDatePos), LoanDateLen) != null && LoanDatePos != null)
                                {
                                    var loandate = line.Substring(int.Parse(LoanDatePos), LoanDateLen);
                                    DateTime dt = Convert.ToDateTime(loandate);
                                    loantemp.LoanDate = dt;
                                }
                                else
                                    loantemp.LoanDate = null;

                                if (line.Substring(int.Parse(ValuePos), ValueLen) != null && ValuePos != null)
                                    loantemp.Value = decimal.Parse(line.Substring(int.Parse(ValuePos), ValueLen));
                                else
                                    loantemp.Value = 0;

                                if (line.Substring(int.Parse(PremiumPos), PremiumLen) != null && PremiumPos != null)
                                    loantemp.Premium = decimal.Parse(line.Substring(int.Parse(PremiumPos), PremiumLen));
                                else
                                    loantemp.Premium = 0;

                                if (line.Substring(int.Parse(SettlementDatePos), SettlementDateLen) != null && SettlementDatePos != null)
                                {
                                    var settlementdate = line.Substring(int.Parse(SettlementDatePos), SettlementDateLen);
                                    DateTime dt = Convert.ToDateTime(settlementdate);
                                    loantemp.SettlementDate = dt;
                                }
                                else
                                    loantemp.SettlementDate = loantemp.LoanDate.Value.AddMonths(int.Parse(loantemp.Term.ToString()));

                                loantemps.Add(loantemp);
                            }
                        }
                    }
                    ms.Flush();
                    ViewData["Message"] = "The records are all the data that has been successfully uploaded from the input file." + "\n" +
                                          "You can proceed to load them to the database.";

                    foreach (LoanTemp l in loantemps)
                    {
                        _context.LoanTemps.Add(l);
                    }
                    _context.SaveChanges();

                    return RedirectToAction("LoadLoans", new
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
            viewModel.ComponentList = new SelectList(await _context.Components.ToListAsync(), "ID", "Name", viewModel.ComponentID);
            return View(viewModel);
        }

        // GET: Loans/LoadLoans
        public async Task<IActionResult> LoadLoans(Guid userId, Guid productId)
        {
            var loantemps = await (from p in _context.LoanTemps
                                   .Where(u => u.UserID == userId)
                                   .Include(p => p.Component)
                                   .OrderBy(i => i.IDNumber)
                                      select p).ToListAsync();

            var loanTotal = loantemps.Sum(p => p.Value);
            var premiumTotal = loantemps.Sum(p => p.Premium);

            LoanTempsViewModel viewModel = new LoanTempsViewModel
            {
                LoanTemps = loantemps,
                ProductID = productId,
                UserID = userId,
                PremiumTotal = premiumTotal,
                LoanTotal = loanTotal,
                ComponentID = _context.LoanTemps.FirstOrDefault().ComponentID
            };
            return View(viewModel);
        }

        // GET: Loans/LoadLoansConfirmed
        [HttpPost, ActionName("LoadLoans")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadLoansConfirmed(LoanTempsViewModel viewModel)
        {
            Guid currentUserId = viewModel.UserID;
            Guid currentproductId = viewModel.ProductID;

            BulkHandles bulkhandle = new BulkHandles();

            int newbulkhandle = bulkhandle.GetBulkHandle(_context);

            var loantemps = from p in _context.LoanTemps
                                   .Where(u => u.UserID == currentUserId)
                                   .Include(p => p.Component)
                                   .OrderBy(i => i.IDNumber)
                               select p;

            int recCount = loantemps.Count();

            foreach (var l in loantemps)
            {
                Loan loan = new Loan();

                if (PolicyExists(l.IDNumber))
                {
                    var loanParams = new object[] { Guid.NewGuid(), GetPolicyId(l.IDNumber), l.ComponentID, l.AccountNumber,
                                        l.Term, l.Rate, l.LoanDate, l.Value, l.Premium, l.SettlementDate, newbulkhandle,
                                        DateTime.Now, currentUserId, null, null };

                    await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO Loan(ID, PolicyID, ComponentID, AccountNumber, Term, Rate, LoanDate, " +
                                            "Value, Premium, SettlementDate, BulkHandle, DateAdded, AddedBy, DateModified, ModifiedBy) " +
                                            "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                                            parameters: loanParams);
                }
                else
                {
                    //  Generate a log file and ask user to load on Client and Policy before loading premiums again.
                }
            }

            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM LoanTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var bulkParams = new object[] { newbulkhandle, "Loan", DateTime.Now, recCount, DateTime.Now, currentUserId };

            await _context.Database.ExecuteSqlCommandAsync(
                                    "INSERT INTO BulkHandleGenerator(BulkNumber, TableName, BulkDate, RecordCount, DateAdded, AddedBy) " +
                                    "Values ({0}, {1}, {2}, {3}, {4}, {5})",
                                    parameters: bulkParams);

            return RedirectToAction("ProductClients", "Products", new { productId = currentproductId });
        }

        private Guid GetPolicyId(string IDNumber)
        {
            Guid clientId = _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
            return _context.Policies.Single(c => c.ClientID == clientId).ID;
        }

        private bool PolicyExists(string IDNumber)
        {
            Guid clientId = _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
            return _context.Policies.Any(c => c.ClientID == clientId);
        }

        private bool LoanExists(Guid id)
        {
            return _context.Loans.Any(e => e.ID == id);
        }
    }
}
