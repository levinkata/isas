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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class PoliciesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PoliciesController(InsurerDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> AddBankAccount(Guid productId, Guid clientId, Guid policyId)
        {
            var banks = await _context.Banks
                                .AsNoTracking()
                                .OrderBy(b => b.Name)
                                .ToListAsync();

            Guid bankId = banks.FirstOrDefault().ID;

            PolicyBankAccountViewModel viewModel = new PolicyBankAccountViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                BankList = new SelectList(banks, "ID", "Name", banks.FirstOrDefault()),
                BankBranchList = new SelectList(await _context.BankBranches
                                                .AsNoTracking()
                                                .Where(b => b.BankID == bankId)
                                                .OrderBy(n => n.Name)
                                                .ToListAsync(), "ID", "Name", await _context.BankBranches.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Policies/AddBankAccount/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBankAccount(PolicyBankAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BankAccount bankaccount = viewModel.BankAccount;
                PolicyBankAccount policybankaccount = new PolicyBankAccount();

                bankaccount.ID = Guid.NewGuid();
                _context.Add(bankaccount);
                await _context.SaveChangesAsync();

                policybankaccount.BankAccountID = bankaccount.ID;
                policybankaccount.PolicyID = viewModel.PolicyID;
                _context.Add(policybankaccount);
                await _context.SaveChangesAsync();

                return RedirectToAction("PolicyBankAccounts", new { productId = viewModel.ProductID,
                                        policyId = viewModel.PolicyID, clientId = viewModel.ClientID });
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BankBranches(Guid bankId)
        {
            var branches = (from b in _context.BankBranches
                                .Where(b => b.BankID == bankId)
                                .OrderBy(n => n.Name)
                                .AsNoTracking()
                            select b).ToList();

            return Json(branches);
        }

        public async Task<IActionResult> GenerateInvoice(Guid policyId)
        {
            var policy = await _context.Policies.SingleOrDefaultAsync(m => m.ID == policyId);
            //var currentProductId = policy.ProductID;
            var currentClientId = policy.ClientID;

            IList<InvoiceItem> invoiceItems = new List<InvoiceItem>();

            var risks = await (from c in _context.Risks
                               where _context.ProductRisks.Any(p => (p.RiskID == c.ID)) // &&
                                                            // (p.ProductID == currentProductId))
                               select c).ToListAsync();

            foreach (Risk risk in risks)
            {
                var riskId = risk.ID;
                
                switch(riskId)
                {
                    case 1:
                        var allrisks = await _context.AllRisks.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        foreach (AllRisk allrisk in allrisks)
                        {
                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                RiskID = riskId,
                                RiskItemID = allrisk.ID,
                                Premium = allrisk.Premium,
                                TaxAmount = 0
                            };
                            invoiceItems.Add(invoiceItem);
                        }
                        break;
                    case 2:
                        var commercials = await _context.Commercials.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        //foreach (Commercial commercial in commercials)
                        //{
                        //    InvoiceItem invoiceItem = new InvoiceItem();
                        //    invoiceItem.RiskID = riskId;
                        //    invoiceItem.RiskItemID = commercials.ID;
                        //    invoiceItem.Premium = commercials.Premium;
                        //    invoiceItem.TaxAmount = 0;
                        //    invoiceItems.Add(invoiceItem);
                        //}
                        break;
                    case 3:
                        var contents = await _context.Contents.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        foreach (Content content in contents)
                        {
                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                RiskID = riskId,
                                RiskItemID = content.ID,
                                Premium = content.Premium,
                                TaxAmount = 0
                            };
                            invoiceItems.Add(invoiceItem);
                        }
                        break;
                    case 4:
                        var loans = await _context.Loans.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        foreach (Loan loan in loans)
                        {
                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                RiskID = riskId,
                                RiskItemID = loan.ID,
                                Premium = loan.Premium,
                                TaxAmount = 0
                            };
                            invoiceItems.Add(invoiceItem);
                        }
                        break;
                    case 5:
                        var motors = await _context.Motors.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        foreach (Motor motor in motors)
                        {
                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                RiskID = riskId,
                                RiskItemID = motor.ID,
                                Premium = motor.Premium,
                                TaxAmount = 0
                            };
                            invoiceItems.Add(invoiceItem);
                        }
                        break;
                    case 6:
                        var properties = await _context.Properties.Where(p => p.PolicyID == policyId).AsNoTracking().ToListAsync();
                        foreach (Property property in properties)
                        {
                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                RiskID = riskId,
                                RiskItemID = property.ID,
                                Premium = property.Premium,
                                TaxAmount = 0
                            };
                            invoiceItems.Add(invoiceItem);
                        }
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            }

            InvoiceNumbers invoicenumber = new InvoiceNumbers(_context);
            var invoiceNumber = invoicenumber.GetInvoiceNumber();

            var myParams = new object[] { invoiceNumber, policyId, DateTime.Now, 0 };

            await _context.Database.ExecuteSqlCommandAsync(
                                        "INSERT INTO Invoice(ID, PolicyID, InvoiceDate, Status) " +
                                        "Values ({0}, {1}, {2}, {3})",
                                        parameters: myParams);

            foreach (InvoiceItem item in invoiceItems)
            {
                var taxAmount = TaxAmount(policyId, item.Premium);

                var myItemParams = new object[] { Guid.NewGuid(), invoiceNumber, item.RiskID, item.RiskItemID, item.Premium, taxAmount };

                await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO InvoiceItem(ID, InvoiceID, RiskID, RiskItemID, Premium, TaxAmount) " +
                                            "Values ({0}, {1}, {2}, {3}, {4}, {5})",
                                            parameters: myItemParams);
            }

            var invParams = new object[] { invoiceNumber };

            await _context.Database.ExecuteSqlCommandAsync(
                                    "INSERT INTO InvoiceNumberGenerator(InvoiceNumber) " +
                                    "Values ({0})",
                                    parameters: invParams);

            return RedirectToAction("Index", new { productId = Guid.Empty, clientId = currentClientId });
        }

        // GET: Policies
        public async Task<IActionResult> Index(Guid productId, Guid clientId)
        {
            var  policies = await _context.Policies
                                .Include(p => p.Client)
                                .Include(p => p.Insurer)
                                .Include(p => p.PolicyFrequency)
                                .Include(p => p.PolicyStatus)
                                //.Include(p => p.Product)
                                .AsNoTracking()
                                //.Where(p => p.ProductID == productId && p.ClientID == clientId)
                                .ToListAsync();

            PoliciesViewModel viewModel = new PoliciesViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                ClientName = ClientName(clientId),
                Policies = policies
            };
            return View(viewModel);
        }

        // GET: Policies/PolicySchedule
        public IActionResult PolicySchedule()
        {
            return View();
        }

        public async Task<IActionResult> PolicyBankAccounts(Guid productId, Guid clientId, Guid policyId)
        {
            PolicyBankAccountsViewModel viewModel = new PolicyBankAccountsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                BankAccounts = await (from b in _context.BankAccounts
                                      .Include(a => a.BankBranch)
                                        .ThenInclude(h => h.Bank)
                                      where _context.PolicyBankAccounts.Any(r => (r.BankAccountID == b.ID) &&
                                      (r.PolicyID == policyId))
                                      orderby b.BankBranch.Name
                                      select b).ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> PolicyExtract(string policyNumber)
        {
            var product = await (from r in _context.Products
                                 where _context.Policies.Any(p => // p.ProductID == r.ID &&
                                 p.PolicyNumber == policyNumber)
                                 select r).SingleOrDefaultAsync();

            var policy = await (from p in _context.Policies
                                .Include(f => f.PolicyFrequency)
                                where p.PolicyNumber.Equals(policyNumber)
                                select p).SingleOrDefaultAsync();

            var client = await (from c in _context.Clients
                                where _context.Policies.Any(p => (p.ClientID == c.ID) &&
                                (p.PolicyNumber == policyNumber))
                                select c).SingleOrDefaultAsync();

            var insurer = await (from i in _context.Insurers
                                 where _context.Policies.Any(p => (p.InsurerID == i.ID) &&
                                 (p.PolicyNumber == policyNumber))
                                 select i).SingleOrDefaultAsync();

            var allrisks = await (from a in _context.AllRisks
                                  .Include(a => a.Component)
                                  where _context.Policies.Any(p => (p.ID == a.PolicyID) &&
                                  (p.PolicyNumber == policyNumber))
                                  orderby a.Component.Name
                                  select a).ToListAsync();

            var commercials = await (from a in _context.Commercials
                                  .Include(a => a.Component)
                                  where _context.Policies.Any(p => (p.ID == a.PolicyID) &&
                                  (p.PolicyNumber == policyNumber))
                                  orderby a.Component.Name
                                  select a).ToListAsync();

            var contents = await (from c in _context.Contents
                                  .Include(a => a.ResidenceType)
                                  .Include(a => a.WallType)
                                  .Include(a => a.RoofType)
                                  where _context.Policies.Any(p => (p.ID == c.PolicyID) &&
                                  (p.PolicyNumber == policyNumber))
                                  orderby c.Location
                                  select c).ToListAsync();

            var loans = await (from l in _context.Loans
                               .Include(a => a.Component)
                               where _context.Policies.Any(p => (p.ID == l.PolicyID) &&
                               (p.PolicyNumber == policyNumber))
                               orderby l.Component.Name
                               select l).ToListAsync();

            var motors = await (from m in _context.Motors
                                .Include(m => m.Coverage)
                                .Include(m => m.DriverType)
                                .Include(m => m.MotorMake)
                                .Include(m => m.MotorType)
                                where _context.Policies.Any(p => (p.ID == m.PolicyID) &&
                                (p.PolicyNumber == policyNumber))
                                orderby m.RegistrationNumber
                                select m).ToListAsync();

            var properties = await (from r in _context.Properties
                                    .Include(a => a.Coverage)
                                    .Include(a => a.ResidenceType)
                                    .Include(a => a.WallType)
                                    .Include(a => a.RoofType)
                                    where _context.Policies.Any(p => (p.ID == r.PolicyID) &&
                                    (p.PolicyNumber == policyNumber))
                                    orderby r.Location
                                    select r).ToListAsync();

            var claims = await (from c in _context.Claims
                                .Include(c => c.ClaimClass)
                                .Include(c => c.ClaimStatus)
                                .Include(c => c.Incident)
                                .Include(c => c.Region)
                                where _context.Policies.Any(p => (p.ID == c.PolicyID) &&
                                (p.PolicyNumber == policyNumber))
                                orderby c.IncidentDate
                                select c).ToListAsync();

            var premiums = await (from r in _context.Premiums
                                 .Include(p => p.Policy)
                                 .Include(t => t.PremiumType)
                                 .Include(r => r.Receivable)
                                    .ThenInclude(p => p.PaymentType)
                                  where _context.Policies.Any(p => (p.ID == r.PolicyID) &&
                                  (p.PolicyNumber == policyNumber))
                                  orderby r.PremiumDate
                                  select r).ToListAsync();

            PolicyExtractViewModel viewModel = new PolicyExtractViewModel
            {
                Product = product,
                Insurer = insurer,
                Client = client,
                Policy = policy,
                AllRisks = allrisks,
                Commercials = commercials,
                Contents = contents,
                Loans = loans,
                Motors = motors,
                Properties = properties,
                Claims = claims
            };
            return View(viewModel);
        }
        public async Task<IActionResult> PolicyRisks(Guid productId, Guid clientId, Guid policyId)
        {
            var risks = await (from c in _context.Risks
                               where _context.ProductRisks.Any(p => (p.RiskID == c.ID) &&
                                                            (p.ProductID == productId))
                               select c).ToListAsync();

            PolicyRisksViewModel viewModel = new PolicyRisksViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                ClientName = ClientName(clientId),
                Risks = risks
            };
            return View(viewModel);
        }

        // GET: Policies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies
                            .Include(i => i.Insurer)
                            .Include(f => f.PolicyFrequency)
                            .Include(s => s.PolicyStatus)
                            .SingleOrDefaultAsync(m => m.ID == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // GET: Policies/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId)
        {
            var policy = new Policy
            {
                //ProductID = productId,
                ClientID = clientId,

                InceptionDate = DateTime.Now,
                EffectiveDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                PremiumDueDate = DateTime.Now,
                StatusDate = DateTime.Now,
                PolicyVersion = 1
            };

            PolicyViewModel viewModel = new PolicyViewModel
            {
                Policy = policy,
                InsurerList = new SelectList(await _context.Insurers
                                                .AsNoTracking()
                                                .OrderBy(n => n.Name)
                                                .ToListAsync(), "ID", "Name"),
                PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                                        .AsNoTracking()
                                                        .ToListAsync(), "ID", "Name"),
                PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                                    .AsNoTracking()
                                                    .ToListAsync(), "ID", "Name"),
                IncomeClassList = new SelectList(await _context.IncomeClasses
                                                    .AsNoTracking()
                                                    .ToListAsync(), "ID", "Name")
            };
            return View(viewModel);
        }

        // POST: Policies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PolicyViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var currentProductId = viewModel.Policy.ProductID;
                    var currentClientId = viewModel.Policy.ClientID;
                    var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                    Policy policy = viewModel.Policy;
                    policy.ID = Guid.NewGuid();
                    policy.PolicyNumber = GetPolicyNumber();
                    policy.BulkHandle = 0;
                    policy.AddedBy = currentUserId;
                    policy.DateAdded = DateTime.Now;
                    policy.ModifiedBy = null;
                    policy.DateModified = null;
                    _context.Add(policy);
                    await _context.SaveChangesAsync();

                    var myParams = new object[] { policy.PolicyNumber };

                    await _context.Database.ExecuteSqlCommandAsync(
                                                "INSERT INTO PolicyNumberGenerator(PolicyNumber) " +
                                                "Values ({0})",
                                                parameters: myParams);
                    return RedirectToAction("Index", new
                    {
                        productId = Guid.Empty,
                        clientId = currentClientId
                    });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;

                //if (errorMsg.Contains("IX_Client_IDNumber"))
                //    viewModel.ErrMsg = $"Duplicate ID Number {idNumber} exists.";

                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.InsurerList = new SelectList(await _context.Insurers
                                        .AsNoTracking()
                                        .OrderBy(n => n.Name)
                                        .ToListAsync(), "ID", "Name", viewModel.Policy.InsurerID);

            viewModel.PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyFrequencyID);

            viewModel.PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyStatusID);

            viewModel.IncomeClassList = new SelectList(await _context.IncomeClasses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.IncomeClassID);

            return View(viewModel);
        }

        // GET: Policies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            var policy = await _context.Policies
                            .Include(i => i.Insurer)
                            .Include(f => f.PolicyFrequency)
                            .Include(s => s.PolicyStatus)
                            .SingleOrDefaultAsync(m => m.ID == id);

            PolicyViewModel viewModel = new PolicyViewModel
            {
                Policy = policy,
                InsurerList = new SelectList(await _context.Insurers
                                    .AsNoTracking()
                                    .OrderBy(n => n.Name)
                                    .ToListAsync(), "ID", "Name", policy.InsurerID),
                PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", policy.PolicyFrequencyID),
                PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", policy.PolicyStatusID),
                IncomeClassList = new SelectList(await _context.IncomeClasses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", policy.IncomeClassID)
            };
            return View(viewModel);
        }

        // POST: Policies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PolicyViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                    Policy policy = new Policy();
                    policy = viewModel.Policy;
                    policy.ModifiedBy = currentUserId;
                    policy.DateModified = DateTime.Now;
                    _context.Update(policy);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { productId = Guid.Empty, clientId = policy.ClientID });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;
                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.InsurerList = new SelectList(await _context.Insurers
                                        .AsNoTracking()
                                        .OrderBy(n => n.Name)
                                        .ToListAsync(), "ID", "Name", viewModel.Policy.InsurerID);
            viewModel.PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyFrequencyID);
            viewModel.PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyStatusID);
            viewModel.IncomeClassList = new SelectList(await _context.IncomeClasses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.IncomeClassID);
            return View(viewModel);
        }

        // GET: Policies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies.SingleOrDefaultAsync(m => m.ID == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var policy = await _context.Policies.SingleOrDefaultAsync(m => m.ID == id);
            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { productid = Guid.Empty, clientid = policy.ClientID });
        }

        // GET: Products/BulkPolicy
        public async Task<IActionResult> BulkPolicy(Guid loadFormatId, UploadFileTypes uploadFileType, string delimiter)
        {

            UpLoadPolicyViewModel viewModel = new UpLoadPolicyViewModel
            {
                LoadFormatID = loadFormatId,
                UploadFileType = uploadFileType,
                Delimiter = delimiter,
                TableName = "Policy",
                InsurerList = new SelectList(await _context.Insurers
                                    .AsNoTracking()
                                    .OrderBy(n => n.Name)
                                    .ToListAsync(), "ID", "Name", await _context.Insurers.FirstOrDefaultAsync()),
                PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", await _context.PolicyFrequencies.FirstOrDefaultAsync()),
                PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", await _context.PolicyStatuses.FirstOrDefaultAsync()),
                IncomeClassList = new SelectList(await _context.IncomeClasses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", await _context.IncomeClasses.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Products/BulkPolicy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkPolicy(UpLoadPolicyViewModel viewModel)
        {
            Guid currentproductId = Guid.Parse(HttpContext.Session.GetString("ProductID"));
            Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int startRow = viewModel.StartRow;

            string IDNumberPos = string.Empty;
            string InsurerNumberPos = string.Empty;
            string CoverStartDatePos = string.Empty;
            string CoverEndDatePos = string.Empty;

        //  Uncomment/comment the below if residue data was not deleted in the ClientTemp table.

        Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM PolicyTemp WHERE UserID = {0}",
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
                    case "InsurerNumber":
                        InsurerNumberPos = row.Position;
                        break;
                    case "CoverStartDate":
                        CoverStartDatePos = row.Position;
                        break;
                    case "CoverEndDate":
                        CoverEndDatePos = row.Position;
                        break;
                    case "default":
                        break;
                }
            }

            IFormFile uploadFile = viewModel.UpLoadFile;
            IList<PolicyTemp> policytemps = new List<PolicyTemp>();

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
                                PolicyTemp policytemp = new PolicyTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PolicyNumber = string.Empty,
                                    InsurerID = viewModel.InsurerID,
                                    PolicyFrequencyID = viewModel.PolicyFrequencyID,
                                    PolicyStatusID = viewModel.PolicyStatusID,
                                    PolicyVersion = viewModel.PolicyVersion,
                                    Renewable = viewModel.Renewable,
                                    StatusDate = viewModel.StatusDate,
                                    InceptionDate = viewModel.InceptionDate,
                                    PremiumDueDate = viewModel.PremiumDueDate
                                };

                                if (worksheet.Cells[IDNumberPos + row].Value != null && IDNumberPos != null)
                                    policytemp.IDNumber = worksheet.Cells[IDNumberPos + row].Value.ToString().Trim();
                                else
                                    break;

                                if (worksheet.Cells[InsurerNumberPos + row].Value != null && InsurerNumberPos != null)
                                    policytemp.InsurerNumber = worksheet.Cells[InsurerNumberPos + row].Value.ToString().Trim();
                                else
                                    policytemp.InsurerNumber = string.Empty;

                                if (worksheet.Cells[CoverStartDatePos + row].Value != null && CoverStartDatePos != null)
                                {
                                    var coverstartdate = worksheet.Cells[CoverStartDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(coverstartdate);
                                    policytemp.EffectiveDate = dt;
                                }
                                else
                                    policytemp.EffectiveDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                if (worksheet.Cells[CoverEndDatePos + row].Value != null && CoverEndDatePos != null)
                                {
                                    var coverenddate = worksheet.Cells[CoverEndDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(coverenddate);
                                    policytemp.ExpiryDate = dt;
                                }
                                else
                                    policytemp.ExpiryDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                policytemps.Add(policytemp);
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
                                PolicyTemp policytemp = new PolicyTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PolicyNumber = string.Empty,
                                    InsurerID = viewModel.InsurerID,
                                    PolicyFrequencyID = viewModel.PolicyFrequencyID,
                                    PolicyStatusID = viewModel.PolicyStatusID,
                                    PolicyVersion = viewModel.PolicyVersion,
                                    Renewable = viewModel.Renewable,
                                    StatusDate = viewModel.StatusDate,
                                    InceptionDate = viewModel.InceptionDate,
                                    PremiumDueDate = viewModel.PremiumDueDate
                                };

                                string[] cols = line.Split(delimiter);

                                if (cols[int.Parse(IDNumberPos)] != null && IDNumberPos != null)
                                    policytemp.IDNumber = cols[int.Parse(IDNumberPos)];
                                else
                                    break;

                                if (cols[int.Parse(InsurerNumberPos)] != null && InsurerNumberPos != null)
                                    policytemp.InsurerNumber = cols[int.Parse(InsurerNumberPos)];
                                else
                                    policytemp.InsurerNumber = string.Empty;

                                if (cols[int.Parse(CoverStartDatePos)] != null && CoverStartDatePos != null)
                                {
                                    var coverstartdate = cols[int.Parse(CoverStartDatePos)];
                                    DateTime dt = Convert.ToDateTime(coverstartdate);
                                    policytemp.EffectiveDate = dt;
                                }
                                else
                                    policytemp.EffectiveDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                if (cols[int.Parse(CoverEndDatePos)] != null && CoverEndDatePos != null)
                                {
                                    var coverenddate = cols[int.Parse(CoverEndDatePos)];
                                    DateTime dt = Convert.ToDateTime(coverenddate);
                                    policytemp.ExpiryDate = dt;
                                }
                                else
                                    policytemp.ExpiryDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                policytemps.Add(policytemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.FixedLengthDelimited)
                    {
                        int IDNumberLen = 0;
                        int InsurerNumberLen = 0;
                        int CoverStartDateLen = 0;
                        int CoverEndDateLen = 0;

                        foreach (var row in formattypes)
                        {
                            switch (row.FieldName)
                            {
                                case "IDNumber":
                                    IDNumberLen = row.ColumnLength;
                                    break;
                                case "InsurerNumber":
                                    InsurerNumberLen = row.ColumnLength;
                                    break;
                                case "CoverStartDate":
                                    CoverStartDateLen = row.ColumnLength;
                                    break;
                                case "CoverEndDate":
                                    CoverEndDateLen = row.ColumnLength;
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
                                PolicyTemp policytemp = new PolicyTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId,
                                    PolicyNumber = string.Empty,
                                    InsurerID = viewModel.InsurerID,
                                    PolicyFrequencyID = viewModel.PolicyFrequencyID,
                                    PolicyStatusID = viewModel.PolicyStatusID,
                                    PolicyVersion = viewModel.PolicyVersion,
                                    Renewable = viewModel.Renewable,
                                    StatusDate = viewModel.StatusDate,
                                    InceptionDate = viewModel.InceptionDate,
                                    PremiumDueDate = viewModel.PremiumDueDate
                                };

                                if (line.Substring(int.Parse(IDNumberPos), IDNumberLen) != null && IDNumberPos != null)
                                    policytemp.IDNumber = line.Substring(int.Parse(IDNumberPos), IDNumberLen);
                                else
                                    break;

                                if (line.Substring(int.Parse(InsurerNumberPos), InsurerNumberLen) != null && InsurerNumberPos != null)
                                    policytemp.InsurerNumber = line.Substring(int.Parse(InsurerNumberPos), InsurerNumberLen);
                                else
                                    policytemp.InsurerNumber = string.Empty;

                                if (line.Substring(int.Parse(CoverStartDatePos), CoverStartDateLen) != null && CoverStartDatePos != null)
                                {
                                    var coverstartdate = line.Substring(int.Parse(CoverStartDatePos), CoverStartDateLen);
                                    DateTime dt = Convert.ToDateTime(coverstartdate);
                                    policytemp.EffectiveDate = dt;
                                }
                                else
                                    policytemp.EffectiveDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                if (line.Substring(int.Parse(CoverEndDatePos), CoverEndDateLen) != null && CoverEndDatePos != null)
                                {
                                    var coverenddate = line.Substring(int.Parse(CoverEndDatePos), CoverEndDateLen);
                                    DateTime dt = Convert.ToDateTime(coverenddate);
                                    policytemp.ExpiryDate = dt;
                                }
                                else
                                    policytemp.ExpiryDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                                                CultureInfo.CurrentCulture.DateTimeFormat);

                                policytemps.Add(policytemp);
                            }
                        }
                    }
                    ms.Flush();
                    ViewData["Message"] = "The records are all the data that has been successfully uploaded from the input file." + "\n" +
                                          "You can proceed to load them to the database.";

                    foreach (PolicyTemp p in policytemps)
                    {
                        _context.PolicyTemps.Add(p);
                    }
                    _context.SaveChanges();

                    return RedirectToAction("LoadPolicies", new
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
            viewModel.InsurerList = new SelectList(await _context.Insurers
                                        .AsNoTracking()
                                        .OrderBy(n => n.Name)
                                        .ToListAsync(), "ID", "Name", viewModel.InsurerID);
            viewModel.PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                                .AsNoTracking()
                                                .OrderBy(n => n.Name)
                                                .ToListAsync(), "ID", "Name", viewModel.PolicyFrequencyID);
            viewModel.PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                            .AsNoTracking()
                                            .OrderBy(n => n.Name)
                                            .ToListAsync(), "ID", "Name", viewModel.PolicyStatusID);
            viewModel.IncomeClassList = new SelectList(await _context.IncomeClasses
                                            .AsNoTracking()
                                            .OrderBy(n => n.Name)
                                            .ToListAsync(), "ID", "Name", viewModel.IncomeClassList);
            return View(viewModel);
        }

        // GET: Products/LoadPolicies
        public async Task<IActionResult> LoadPolicies(Guid userId, Guid productId)
        {
            var policytemps = await (from p in _context.PolicyTemps
                                   .Where(u => u.UserID == userId)
                                   .Include(c => c.Insurer)
                                   .Include(o => o.PolicyFrequency)
                                   .Include(t => t.PolicyStatus)
                                   .OrderBy(p => p.IDNumber)
                                     select p).ToListAsync();

            PolicyTempsViewModel viewModel = new PolicyTempsViewModel
            {
                ProductID = productId,
                UserID = userId,
                PolicyTemps = policytemps
            };

            return View(viewModel);
        }

        // GET: Products/LoadPoliciesConfirmed
        [HttpPost, ActionName("LoadPolicies")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadPoliciesConfirmed(PolicyTempsViewModel viewModel)
        {
            Guid currentUserId = viewModel.UserID;
            Guid currentproductId = viewModel.ProductID;

            BulkHandles bulkhandle = new BulkHandles();

            int newbulkhandle = bulkhandle.GetBulkHandle(_context);

            var policytemps = from p in _context.PolicyTemps
                                   .Where(u => u.UserID == currentUserId)
                                   .Include(c => c.Insurer)
                                   .Include(o => o.PolicyFrequency)
                                   .Include(t => t.PolicyStatus)
                                   .OrderBy(p => p.IDNumber)
                              select p;

            int recCount = policytemps.Count();

            foreach (var p in policytemps)
            {
                Policy policy = new Policy();

                if (ClientExistOnProduct(p.IDNumber))
                {
                    var policyParams = new object[] { Guid.NewGuid(), currentproductId, GetClientId(p.IDNumber),
                                        p.PolicyNumber, p.InsurerNumber, p.InsurerID, p.PolicyFrequencyID, p.EffectiveDate, p.ExpiryDate,
                                        p.PolicyStatusID, p.StatusDate, p.PremiumDueDate, p.PolicyVersion, p.InceptionDate, p.Renewable,
                                        newbulkhandle, DateTime.Now, currentUserId, null, null };

                    await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO Policy(ID, ProductID, ClientID, PolicyNumber, InsurerNumber, InsurerID, " +
                                            "PolicyFrequencyID, EffectiveDate, ExpiryDate, PolicyStatusID, StatusDate, " +
                                            "PremiumDueDate, PolicyVersion, InceptionDate, Renewable, BulkHandle, DateAdded, AddedBy, DateModified, ModifiedBy) " +
                                            "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, " +
                                            "{15}, {16}, {17}, {18}, {19})",
                                            parameters: policyParams);
                }
                else
                {
                    //  Generate a log file and ask user to load the same on Client table first.
                }
            }
            
            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM PolicyTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var bulkParams = new object[] { newbulkhandle, "Policy", DateTime.Now, recCount, DateTime.Now, currentUserId };

            await _context.Database.ExecuteSqlCommandAsync(
                                    "INSERT INTO BulkHandleGenerator(BulkNumber, TableName, BulkDate, RecordCount, DateAdded, AddedBy) " +
                                    "Values ({0}, {1}, {2}, {3}, {4}, {5})",
                                    parameters: bulkParams);

            return RedirectToAction("ProductClients", "Products", new { productId = currentproductId });
        }

        private void CreateInvoiceRecord(string policyNumber, decimal Premium, int riskId, Guid riskItemId)
        {
            //var myParams = new object[] { policy.ID, policy.PolicyNumber };

            //_context.Database.ExecuteSqlCommandAsync(
            //                            "INSERT INTO Invoice(InvoiceID, PolicyNumber, Amount, TaxAmount, InvoiceDate, InvoiceDueDate, Status) " +
            //                            "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
            //                            parameters: myParams);

            //var myItemParams = new object[] { policy.ID, policy.PolicyNumber };

            //_context.Database.ExecuteSqlCommandAsync(
            //                            "INSERT INTO InvoiceItem(ID, InvoiceID, Premium, TaxAmount, RiskID, RiskItemID) " +
            //                            "Values ({0}, {1}, {2}, {3}, {4})",
            //                            parameters: myItemParams);
        }

        public async Task<IActionResult> Renewal(Guid Id)
        {
            var policy = await _context.Policies
                            .Include(i => i.Insurer)
                            .Include(f => f.PolicyFrequency)
                            .Include(s => s.PolicyStatus)
                            .SingleOrDefaultAsync(m => m.ID == Id);

            PolicyViewModel viewModel = new PolicyViewModel
            {
                Policy = policy,
                InsurerList = new SelectList(await _context.Insurers
                                    .AsNoTracking()
                                    .OrderBy(n => n.Name)
                                    .ToListAsync(), "ID", "Name", policy.InsurerID),
                PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", policy.PolicyFrequencyID),
                PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", policy.PolicyStatusID),
                IncomeClassList = new SelectList(await _context.IncomeClasses
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", policy.IncomeClassID)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Renewal(PolicyViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Policy policy = new Policy();
                    policy = viewModel.Policy;

                    var policyId = viewModel.Policy.ID;
                    var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                    PolicyHistory policyhistory = new PolicyHistory
                    {
                        ID = policyId,
                        //ProductID = policy.ProductID,
                        ClientID = policy.ClientID,
                        PolicyNumber = policy.PolicyNumber,
                        InsurerID = policy.InsurerID,
                        InsurerNumber = policy.InsurerNumber,
                        PolicyFrequencyID = policy.PolicyFrequencyID,
                        CoverStartDate = policy.EffectiveDate,
                        CoverEndDate = policy.ExpireDate,
                        PolicyStatusID = policy.PolicyStatusID,
                        StatusDate = policy.StatusDate,
                        PremiumDueDate = policy.PremiumDueDate,
                        PolicyVersion = policy.PolicyVersion,
                        InceptionDate = policy.InceptionDate,
                        Renewable = policy.Renewable,
                        IncomeClassID = policy.IncomeClassID,
                        Comment = policy.Comment,
                        BulkHandle = policy.BulkHandle,
                        DateAdded = policy.DateAdded,
                        AddedBy = policy.AddedBy,
                        DateModified = policy.DateModified,
                        ModifiedBy = policy.ModifiedBy
                    };
                    _context.Add(policyhistory);
                    await _context.SaveChangesAsync();

                    var divisor = policy.PolicyFrequency.Divisor;
                    var interval = 12 / divisor;

                    //  When to DELETE Policy record
                    _context.Policies.Remove(policy);
                    await _context.SaveChangesAsync();

                    policy.ID = Guid.NewGuid();
                    //policy.CoverStartDate = policy.CoverStartDate.AddMonths(interval);
                    //policy.CoverEndDate = policy.CoverEndDate.AddMonths(interval);
                    policy.StatusDate = DateTime.Now;
                    //policy.PremiumDueDate = policy.PremiumDueDate.AddMonths(interval);
                    policy.PolicyVersion = viewModel.Policy.PolicyVersion + 1;
                    //policy.Comment = string.Empty;
                    policy.BulkHandle = 0;
                    policy.AddedBy = currentUserId;
                    policy.DateAdded = DateTime.Now;
                    policy.ModifiedBy = null;
                    policy.DateModified = null;

                    //  INSERT new Policy record
                    _context.Add(policy);
                    await _context.SaveChangesAsync();

                    //  Sift through all Risks to check if corresponding risks exist for this policyId
                    var allrisks = _context.AllRisks.Where(p => p.PolicyID == policyId).ToList();
                    var commercials = _context.Commercials.Where(p => p.PolicyID == policyId).ToList();
                    var contents = _context.Contents.Where(p => p.PolicyID == policyId).ToList();
                    var loans = _context.Loans.Where(p => p.PolicyID == policyId).ToList();
                    var motors = _context.Motors.Where(p => p.PolicyID == policyId).ToList();
                    var properties = _context.Properties.Where(p => p.PolicyID == policyId).ToList();

                    if (allrisks != null)
                    {
                        foreach (AllRisk allrisk in allrisks)
                        {
                            AllRiskHistory allRiskHistory = new AllRiskHistory
                            {
                                ID = allrisk.ID,
                                PolicyID = allrisk.PolicyID,
                                ComponentID = allrisk.ComponentID,
                                Description = allrisk.Description,
                                Value = allrisk.Value,
                                Premium = allrisk.Premium,
                                StartDate = allrisk.StartDate,
                                EndDate = allrisk.EndDate,
                                Comment = allrisk.Comment,
                                PolicyFee = allrisk.PolicyFee,
                                InsurerFee = allrisk.InsurerFee,
                                Commission = allrisk.Commission,
                                AdminFee = allrisk.AdminFee,
                                DateAdded = allrisk.DateAdded,
                                AddedBy = allrisk.AddedBy,
                                DateModified = allrisk.DateModified,
                                ModifiedBy = allrisk.ModifiedBy
                            };
                            _context.Add(allRiskHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE AllRisk record
                            _context.AllRisks.Remove(allrisk);
                            await _context.SaveChangesAsync();

                            //  INSERT ALLRisk record
                            allrisk.ID = Guid.NewGuid();
                            allrisk.StartDate = policy.EffectiveDate;
                            allrisk.EndDate = policy.ExpireDate;
                            allrisk.Comment = string.Empty;
                            allrisk.AddedBy = currentUserId;
                            allrisk.DateAdded = DateTime.Now;
                            allrisk.ModifiedBy = null;
                            allrisk.DateModified = null;
                            _context.Add(allrisk);
                            await _context.SaveChangesAsync();
                        }
                    };

                    if (commercials != null)
                    {
                        foreach (Commercial commercial in commercials)
                        {
                            CommercialHistory commercialHistory = new CommercialHistory
                            {
                                ID = commercial.ID,
                                PolicyID = commercial.PolicyID,
                                ComponentID = commercial.ComponentID,
                                Description = commercial.Description,
                                Motor = commercial.Motor,
                                Rate = commercial.Rate,
                                Value = commercial.Value,
                                Premium = commercial.Premium,
                                StartDate = commercial.StartDate,
                                EndDate = commercial.EndDate,
                                PolicyFee = commercial.PolicyFee,
                                InsurerFee = commercial.InsurerFee,
                                Commission = commercial.Commission,
                                AdminFee = commercial.AdminFee,
                                DateAdded = commercial.DateAdded,
                                AddedBy = commercial.AddedBy,
                                DateModified = commercial.DateModified,
                                ModifiedBy = commercial.ModifiedBy
                            };
                            _context.Add(commercialHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE Commercial record
                            _context.Commercials.Remove(commercial);
                            await _context.SaveChangesAsync();

                            //  INSERT Commercial record
                            commercial.ID = Guid.NewGuid();
                            commercial.StartDate = policy.EffectiveDate;
                            commercial.EndDate = policy.ExpireDate;
                            commercial.AddedBy = currentUserId;
                            commercial.DateAdded = DateTime.Now;
                            commercial.ModifiedBy = null;
                            commercial.DateModified = null;
                            _context.Add(commercial);
                            await _context.SaveChangesAsync();
                        }
                    };

                    if (contents != null)
                    {
                        foreach (Content content in contents)
                        {
                            ContentHistory contentHistory = new ContentHistory
                            {
                                ID = content.ID,
                                PolicyID = content.PolicyID,
                                Location = content.Location,
                                Value = content.Value,
                                Premium = content.Premium,
                                StartDate = content.StartDate,
                                EndDate = content.EndDate,
                                WallTypeID = content.WallTypeID,
                                RoofTypeID = content.RoofTypeID,
                                ResidenceTypeID = content.ResidenceTypeID,
                                PolicyFee = content.PolicyFee,
                                InsurerFee = content.InsurerFee,
                                Commission = content.Commission,
                                AdminFee = content.AdminFee,
                                DateAdded = content.DateAdded,
                                AddedBy = content.AddedBy,
                                DateModified = content.DateModified,
                                ModifiedBy = content.ModifiedBy
                            };
                            _context.Add(contentHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE Content record
                            _context.Contents.Remove(content);
                            await _context.SaveChangesAsync();

                            //  INSERT Content record
                            content.ID = Guid.NewGuid();
                            content.StartDate = policy.EffectiveDate;
                            content.EndDate = policy.ExpireDate;
                            content.AddedBy = currentUserId;
                            content.DateAdded = DateTime.Now;
                            content.ModifiedBy = null;
                            content.DateModified = null;
                            _context.Add(content);
                            await _context.SaveChangesAsync();
                        }
                    };

                    if (loans != null)
                    {
                        foreach (Loan loan in loans)
                        {
                            LoanHistory loanHistory = new LoanHistory
                            {
                                ID = loan.ID,
                                PolicyID = loan.PolicyID,
                                ComponentID = loan.ComponentID,
                                AccountNumber = loan.AccountNumber,
                                Term = loan.Term,
                                Rate = loan.Rate,
                                LoanDate = loan.LoanDate,
                                Value = loan.Value,
                                Premium = loan.Premium,
                                SettlementDate = loan.SettlementDate,
                                PolicyFee = loan.PolicyFee,
                                InsurerFee = loan.InsurerFee,
                                Commission = loan.Commission,
                                AdminFee = loan.AdminFee,
                                BulkHandle = loan.BulkHandle,
                                DateAdded = loan.DateAdded,
                                AddedBy = loan.AddedBy,
                                DateModified = loan.DateModified,
                                ModifiedBy = loan.ModifiedBy
                            };
                            _context.Add(loanHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE Loan record
                            _context.Loans.Remove(loan);
                            await _context.SaveChangesAsync();

                            //  INSERT Loan record
                            loan.ID = Guid.NewGuid();
                            loan.LoanDate = policy.EffectiveDate;
                            loan.SettlementDate = policy.ExpireDate;
                            loan.AddedBy = currentUserId;
                            loan.DateAdded = DateTime.Now;
                            loan.ModifiedBy = null;
                            loan.DateModified = null;
                            _context.Add(loan);
                            await _context.SaveChangesAsync();
                        }
                    };

                    if (motors != null)
                    {
                        foreach (Motor motor in motors)
                        {
                            MotorHistory motorHistory = new MotorHistory
                            {
                                ID = motor.ID,
                                PolicyID = motor.PolicyID,
                                RegistrationNumber = motor.RegistrationNumber,
                                MotorTypeID = motor.MotorTypeID,
                                MotorMakeID = motor.MotorMakeID,
                                MotorModelID = motor.MotorModelID,
                                ManufacturerYear = motor.ManufacturerYear,
                                EngineNumber = motor.EngineNumber,
                                ChassisNumber = motor.ChassisNumber,
                                Value = motor.Value,
                                Premium = motor.Premium,
                                StartDate = motor.StartDate,
                                EndDate = motor.EndDate,
                                CoverageID = motor.CoverageID,
                                DriverTypeID = motor.DriverTypeID,
                                PrivateUse = motor.PrivateUse,
                                BusinessUse = motor.BusinessUse,
                                CFG = motor.CFG,
                                Immobiliser = motor.Immobiliser,
                                Alarm = motor.Alarm,
                                GreyImport = motor.GreyImport,
                                TerritorialLimit = motor.TerritorialLimit,
                                PolicyFee = motor.PolicyFee,
                                InsurerFee = motor.InsurerFee,
                                Commission = motor.Commission,
                                AdminFee = motor.AdminFee,
                                DateAdded = motor.DateAdded,
                                AddedBy = motor.AddedBy,
                                DateModified = motor.DateModified,
                                ModifiedBy = motor.ModifiedBy
                            };
                            _context.Add(motorHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE Motor record
                            _context.Motors.Remove(motor);
                            await _context.SaveChangesAsync();

                            //  INSERT Motor record
                            motor.ID = Guid.NewGuid();
                            motor.StartDate = policy.EffectiveDate;
                            motor.EndDate = policy.ExpireDate;
                            motor.AddedBy = currentUserId;
                            motor.DateAdded = DateTime.Now;
                            motor.ModifiedBy = null;
                            motor.DateModified = null;
                            _context.Add(motor);
                            await _context.SaveChangesAsync();
                        }
                    };

                    if (properties != null)
                    {
                        foreach (Property property in properties)
                        {
                            PropertyHistory propertyHistory = new PropertyHistory
                            {
                                ID = property.ID,
                                PolicyID = property.PolicyID,
                                Location = property.Location,
                                Value = property.Value,
                                Premium = property.Premium,
                                StartDate = property.StartDate,
                                EndDate = property.EndDate,
                                CoverageID = property.CoverageID,
                                WallTypeID = property.WallTypeID,
                                RoofTypeID = property.RoofTypeID,
                                ResidenceTypeID = property.ResidenceTypeID,
                                PolicyFee = property.PolicyFee,
                                InsurerFee = property.InsurerFee,
                                Commission = property.Commission,
                                AdminFee = property.AdminFee,
                                DateAdded = property.DateAdded,
                                AddedBy = property.AddedBy,
                                DateModified = property.DateModified,
                                ModifiedBy = property.ModifiedBy
                            };
                            _context.Add(propertyHistory);
                            await _context.SaveChangesAsync();

                            //  DELETE Property record
                            _context.Properties.Remove(property);
                            await _context.SaveChangesAsync();

                            //  INSERT Property record
                            property.ID = Guid.NewGuid();
                            property.StartDate = policy.EffectiveDate;
                            property.EndDate = policy.ExpireDate;
                            property.AddedBy = currentUserId;
                            property.DateAdded = DateTime.Now;
                            property.ModifiedBy = null;
                            property.DateModified = null;
                            _context.Add(property);
                            await _context.SaveChangesAsync();
                        }
                    };
                    return RedirectToAction("Index", new { productId = Guid.Empty, clientId = policy.ClientID });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;
                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.InsurerList = new SelectList(await _context.Insurers
                                        .AsNoTracking()
                                        .OrderBy(n => n.Name)
                                        .ToListAsync(), "ID", "Name", viewModel.Policy.InsurerID);
            viewModel.PolicyFrequencyList = new SelectList(await _context.PolicyFrequencies
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyFrequencyID);
            viewModel.PolicyStatusList = new SelectList(await _context.PolicyStatuses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.PolicyStatusID);
            viewModel.IncomeClassList = new SelectList(await _context.IncomeClasses
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Policy.IncomeClassID);
            return View(viewModel);
        }

        private bool PolicyExists(Guid id)
        {
            return _context.Policies.Any(e => e.ID == id);
        }

        private bool PolicyNumberExists(string policynumber)
        {
            return _context.Policies.Any(p => p.PolicyNumber == policynumber);
        }

        private Guid GetClientId(string IDNumber)
        {
            return _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
        }

        public decimal TaxAmount(Guid policyId, decimal amount)
        {
            decimal taxAmount = 0;
            CultureInfo culture = new CultureInfo("en-GB");

            var result = (from c in _context.Countries
                          where _context.Containers.Any(t => (t.CountryID == c.ID) &&
                          _context.Products.Any(p => (p.ContainerID == t.ID) &&
                          _context.Policies.Any(l => // (l.ProductID == p.ID) && 
                          l.ID == policyId)))
                          select c.Tax);

            if (result != null)
            {
                decimal taxRate = Convert.ToDecimal(result.FirstOrDefault().ToString(), culture);
                taxAmount = amount * taxRate / 100;
            }

            return taxAmount;
        }

        private int CompareDates(DateTime startDate, DateTime endDate)
        {
            int result = DateTime.Compare(startDate, endDate);
            //string relationship;

            //if (result < 0)
            //    relationship = "is earlier than";
            //else if (result == 0)
            //    relationship = "is the same time as";
            //else
            //    relationship = "is later than";
            return result;
        }

        private bool ClientExistOnProduct(string IDNumber)
        {
            Guid clientId = _context.Clients.Single(c => c.IDNumber == IDNumber).ID;
            return _context.ProductClients.Any(c => c.ClientID == clientId);
        }

        private string ClientName(Guid clientId)
        {
            //string FullName = string.Empty;
            //var lastName = _context.Clients.SingleOrDefault(c => c.ID == clientId).LastName;
            //var firstName = _context.Clients.SingleOrDefault(c => c.ID == clientId).FirstName;

            //if (string.IsNullOrEmpty(firstName))
            //    FullName = lastName;
            //else
            //    FullName = firstName + " " + lastName;

            return string.IsNullOrEmpty(_context.Clients.SingleOrDefault(c => c.ID == clientId).FirstName) ?
                                _context.Clients.SingleOrDefault(c => c.ID == clientId).LastName :
                                _context.Clients.SingleOrDefault(c => c.ID == clientId).FirstName + " " + _context.Clients.SingleOrDefault(c => c.ID == clientId).LastName;
        }

        private string GetPolicyNumber()
        {
            int lastPolicyNumber = (_context.PolicyNumberGenerators.Count() > 0) ? _context.PolicyNumberGenerators.Max(p => p.PolicyNumber) : 0;
            var newPolicyNumber = lastPolicyNumber + 1;
            return newPolicyNumber.ToString();
        }

        private bool ClientExists(string IdNumber)
        {
            return _context.Clients.Any(e => e.IDNumber == IdNumber);
        }

        string GetFullErrorString()
        {
            var messages = new List<string>();

            foreach (var entry in ModelState.Values)
            {
                foreach (var error in entry.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}
