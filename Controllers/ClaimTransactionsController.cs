using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class ClaimTransactionsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClaimTransactionsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ClaimTransactions
        public async Task<IActionResult> Index(Guid productId, Guid clientId, Guid policyId, int claimNumber)
        {
            var claimtransactions = await _context.ClaimTransactions
                                    .Include(c => c.Account)
                                    .Include(c => c.Affected)
                                    .Include(c => c.Claim)
                                    .Include(c => c.Payee)
                                    .Include(c => c.TransactionType)
                                    .AsNoTracking()
                                    .Where(t => t.ClaimNumber == claimNumber)
                                    .OrderBy(t => t.TransactionNumber)
                                    .ToListAsync();
            ClaimTransactionsViewModel viewModel = new ClaimTransactionsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                ClaimNumber = claimNumber,
                ClaimTransactions = claimtransactions
            };

            return View(viewModel);
        }

        // GET: ClaimTransactions
        public async Task<IActionResult> Paid(Guid productId, int option,
                    string searchString, DateTime StartDate, DateTime EndDate)
        {
            List<SelectListItem> SelectOptions = new List<SelectListItem>
            {
                new SelectListItem() { Text = "All", Value = "0" },
                new SelectListItem() { Text = "Payee", Value = "1" },
                new SelectListItem() { Text = "Invoice Number", Value = "2" },
                new SelectListItem() { Text = "Claim Number", Value = "3" },
                new SelectListItem() { Text = "Reference", Value = "4" },
                new SelectListItem() { Text = "Invoice Date", Value = "5" },
                new SelectListItem() { Text = "Payment Date", Value = "6" }
            };

            var options = new SelectList(SelectOptions, "Value", "Text", option);

            var claimtransactions = await (from c in _context.ClaimTransactions
                                        .Include(c => c.Account)
                                        .Include(c => c.Affected)
                                        .Include(c => c.Claim)
                                        .Include(c => c.Payee)
                                        .Include(c => c.TransactionType)
                                        .Include(c => c.Payable)
                                            .ThenInclude(p => p.PaymentType)
                                        .AsNoTracking()
                                        where _context.Claims.Any(m => (m.ClaimNumber == c.ClaimNumber) &&
                                          _context.Policies.Any(p => (p.ID == m.PolicyID)) &&
                                          //p.ProductID == productId)) &&
                                          c.PayableID != null)
                                        orderby c.Payable.PayableDate descending
                                        select c).ToListAsync();

            ViewBag.datasource = claimtransactions.Select(r => new
                                                    {
                                                        r.ID,
                                                        r.TransactionNumber,
                                                        Payee = r.Payee.Name,
                                                        r.InvoiceNumber,
                                                        r.InvoiceDate,
                                                        r.RequisitionDate,
                                                        r.Amount,
                                                        r.ClaimNumber,
                                                        r.Payable.Reference,
                                                        r.Payable.PayableDate,
                                                        PaymentType = r.Payable.PaymentType.Name
                                                    }).ToList();
            
            switch (option)
            {
                case 0:
                    claimtransactions = claimtransactions
                                        .OrderBy(c => c.Payable.PayableDate).ToList();
                    break;
                case 1:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 2:
                    claimtransactions = claimtransactions
                                        .Where(c => c.InvoiceNumber.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 3:
                    //  Check if Claim Number is int
                    int claimNumber = int.Parse(searchString);
                    claimtransactions = claimtransactions
                                        .Where(c => c.ClaimNumber == claimNumber).ToList();
                    break;
                case 4:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payable.Reference.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 5:
                    claimtransactions = claimtransactions
                                        .Where(c => c.InvoiceDate >= StartDate
                                                && c.InvoiceDate <= EndDate).ToList();
                    break;
                case 6:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payable.PayableDate >= StartDate
                                                && c.Payable.PayableDate <= EndDate).ToList();
                    break;
                default:
                    break;
            }

            ViewData["ProductID"] = productId;
            ViewData["SelectOptions"] = options;
            ViewData["StartDate"] = StartDate;
            ViewData["EndDate"] = EndDate;
            ViewData["ProductName"] = ProductName(productId);
            return View(claimtransactions);
        }

        // GET: PopulateTable
        [HttpPost]
        public async Task<IActionResult> PopulateTable(Guid productId, int option,
                                            string searchString, DateTime StartDate, DateTime EndDate)
        {
            var claimtransactions = await (from c in _context.ClaimTransactions
                                        .Include(c => c.Account)
                                        .Include(c => c.Affected)
                                        .Include(c => c.Claim)
                                        .Include(c => c.Payee)
                                        .Include(c => c.TransactionType)
                                        .Include(c => c.Payable)
                                            .ThenInclude(p => p.PaymentType)
                                        .AsNoTracking()
                                           where _context.Claims.Any(m => (m.ClaimNumber == c.ClaimNumber) &&
                                                _context.Policies.Any(p => (p.ID == m.PolicyID))) &&
                                                //p.ProductID == productId)) &&
                                                c.PayableID != null
                                           orderby c.Payable.PayableDate descending
                                           select c).ToListAsync();

            switch (option)
            {
                case 0:
                    claimtransactions = claimtransactions
                                        .OrderBy(c => c.Payable.PayableDate).ToList();
                    break;
                case 1:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 2:
                    claimtransactions = claimtransactions
                                        .Where(c => c.InvoiceNumber.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 3:
                    //  Check if Claim Number is int
                    int claimNumber = int.Parse(searchString);
                    claimtransactions = claimtransactions
                                        .Where(c => c.ClaimNumber == claimNumber).ToList();
                    break;
                case 4:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payable.Reference.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case 5:
                    claimtransactions = claimtransactions
                                        .Where(c => c.InvoiceDate >= StartDate &&
                                                c.InvoiceDate <= EndDate).ToList();
                    break;
                case 6:
                    claimtransactions = claimtransactions
                                        .Where(c => c.Payable.PayableDate >= StartDate &&
                                                c.Payable.PayableDate <= EndDate).ToList();
                    break;
                default:
                    break;
            }

            var data = claimtransactions.Select(c => new
                                            {
                                                TransactionNumber = c.TransactionNumber.ToString(),
                                                PayeeName = c.Payee.Name,
                                                c.InvoiceNumber,
                                                c.InvoiceDate,
                                                c.RequisitionDate,
                                                Amount = c.Amount.ToString(),
                                                ClaimNumber = c.ClaimNumber.ToString(),
                                                c.Payable.Reference,
                                                c.Payable.PayableDate,
                                                PaymentType = c.Payable.PaymentType.Name
                                            }).ToList();

            return Json(data);
        }

        [HttpPost]
        public IActionResult ShowDescription(Guid Id)
        {
            var accountchart = _context.AccountCharts
                                .Where(a => a.ID == Id)
                                .ToList().Select(r => new SelectListItem
                                {
                                    Value = r.ID.ToString(),
                                    Text = r.Description
                                });

            return Json(accountchart);
        }

        // GET: ClaimTransactions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimTransaction = await _context.ClaimTransactions.SingleOrDefaultAsync(m => m.ID == id);
            if (claimTransaction == null)
            {
                return NotFound();
            }

            return View(claimTransaction);
        }

        // GET: ClaimTransactions/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId, int claimNumber)
        {
            ClaimTransaction claimtransaction = new ClaimTransaction
            {
                ClaimNumber = claimNumber,
                Taxable = true,
                TaxAmount = 0,
                RequisitionDate = DateTime.Now,
                InvoiceDate = DateTime.Now
            };

            ClaimTransactionViewModel viewModel = new ClaimTransactionViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                ClaimNumber = claimNumber,
                ClaimTransaction = claimtransaction,
                PayeeList = new SelectList(await _context.Payees
                                    .AsNoTracking()
                                    .OrderBy(p => p.Name).ToListAsync(), "ID", "Name"),
                AccountList = new SelectList(await _context.AccountCharts
                                    .AsNoTracking()
                                    .OrderBy(p => p.AccountCode).ToListAsync(), "ID", "AccountCode"),
                AffectedList = new SelectList(await _context.Affecteds
                                    .AsNoTracking().ToListAsync(), "ID", "Name"),
                TransactionTypeList = new SelectList(await _context.TransactionTypes
                                            .AsNoTracking().ToListAsync(), "ID", "Name")
            };
            return View(viewModel);
        }

        // POST: ClaimTransactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimTransactionViewModel viewModel)
        {
            var invoiceNumber = viewModel.ClaimTransaction.InvoiceNumber;
            var currentProductId = viewModel.ProductID;
            var currentClientId = viewModel.ClientID;
            var currentPolicyId = viewModel.PolicyID;
            var currentClaimNumber = viewModel.ClaimTransaction.ClaimNumber;

            try
            {
                if (ModelState.IsValid)
                {
                    ClaimTransaction claimTransaction = new ClaimTransaction();
                    TransactionNumbers transactionnumber = new TransactionNumbers();

                    claimTransaction = viewModel.ClaimTransaction;
                    claimTransaction.ID = Guid.NewGuid();
                    claimTransaction.ClaimNumber = viewModel.ClaimNumber;
                    claimTransaction.TransactionNumber = transactionnumber.GetTransactionNumber(_context);
                    claimTransaction.TaxAmount = TaxAmount(claimTransaction.Taxable, claimTransaction.Amount, claimTransaction.ClaimNumber);
                    _context.Add(claimTransaction);
                    await _context.SaveChangesAsync();

                    var tranParam = claimTransaction.TransactionNumber;

                    await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO ClaimTransactionGenerator(TransactionNumber) " +
                                            "Values ({0})",
                                            parameters: tranParam);

                    return RedirectToAction("Index", new {
                        productId = currentProductId, clientId = currentClientId,
                        policyId = currentPolicyId, claimId = currentClaimNumber });
                }
            }
            catch(DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;

                if (errorMsg.Contains("IX_ClaimTransaction_InvoiceNumber"))
                {
                    viewModel.ErrMsg = $"Duplicate Invoice Number {invoiceNumber} exists.";
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }

                ModelState.AddModelError(string.Empty, ex.InnerException.Message.ToString());
            }

            viewModel.PayeeList = new SelectList(await _context.Payees.OrderBy(p => p.Name)
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name",viewModel.ClaimTransaction.ID);
            viewModel.AccountList = new SelectList(await _context.AccountCharts
                                        .AsNoTracking()
                                        .OrderBy(p => p.AccountCode).ToListAsync(), "ID", "AccountCode", viewModel.ClaimTransaction.AccountID);
            viewModel.AffectedList = new SelectList(await _context.Affecteds
                                        .AsNoTracking()
                                        .OrderBy(p => p.Name).ToListAsync(), "ID", "Name", viewModel.ClaimTransaction.AffectedID);
            viewModel.TransactionTypeList = new SelectList(await _context.TransactionTypes
                                                .AsNoTracking()
                                                .OrderByDescending(p => p.Name).ToListAsync(), "ID", "Name", viewModel.ClaimTransaction.TransactionTypeID);
            return View(viewModel);
        }

        // GET: ClaimTransactions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimTransaction = await _context.ClaimTransactions.SingleOrDefaultAsync(m => m.ID == id);
            if (claimTransaction == null)
            {
                return NotFound();
            }

            ClaimTransactionViewModel viewModel = new ClaimTransactionViewModel
            {
                ClaimTransaction = claimTransaction,
                AccountList = new SelectList(_context.AccountCharts, "ID", "AccountCode", claimTransaction.AccountID),
                AffectedList = new SelectList(_context.Affecteds, "ID", "Name", claimTransaction.AffectedID),
                PayeeList = new SelectList(_context.Payees, "ID", "Name", claimTransaction.PayeeID),
                TransactionTypeList = new SelectList(_context.TransactionTypes, "ID", "Name", claimTransaction.TransactionTypeID)
            };
            return View(viewModel);
        }

        // POST: ClaimTransactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClaimTransactionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimTransaction claimTransaction = new ClaimTransaction();
                claimTransaction = viewModel.ClaimTransaction;
                claimTransaction.TaxAmount = TaxAmount(claimTransaction.Taxable, claimTransaction.Amount, claimTransaction.ClaimNumber);

                try
                {
                    _context.Update(claimTransaction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { claimId = claimTransaction .ClaimNumber });
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message.ToString());
                }

            }
            viewModel.AccountList = new SelectList(_context.AccountCharts, "ID", "AccountCode", viewModel.ClaimTransaction.AccountID);
            viewModel.AffectedList = new SelectList(_context.Affecteds, "ID", "Name", viewModel.ClaimTransaction.AffectedID);
            viewModel.PayeeList = new SelectList(_context.Payees, "ID", "Name", viewModel.ClaimTransaction.PayeeID);
            viewModel.TransactionTypeList = new SelectList(_context.TransactionTypes, "ID", "Name", viewModel.ClaimTransaction.TransactionTypeID);
            return View(viewModel);
        }

        // GET: ClaimTransactions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimTransaction = await _context.ClaimTransactions.SingleOrDefaultAsync(m => m.ID == id);
            if (claimTransaction == null)
            {
                return NotFound();
            }

            return View(claimTransaction);
        }

        // POST: ClaimTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var claimTransaction = await _context.ClaimTransactions.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClaimTransactions.Remove(claimTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //private int GetClaimTransaction()
        //{
        //    return _context.Database.ExecuteSqlCommand("GetTransactionNumber @NextTransactionNumber");
        //}

        [HttpPost]
        public async Task<IActionResult> Authorise(Guid Id, bool authorised)
        {
            bool authValue = authorised ? false : true;
            var userId = authValue ? this.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            var myParams = new object[] { authValue, userId, Id };

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE ClaimTransaction SET Authorised = {0}, AuthoriserID = {1} WHERE ID = {2}",
                parameters: myParams);

            return Json(authValue);
        }

        public decimal TaxAmount(bool taxable, decimal amount, int claimId)
        {
            decimal taxAmount = 0;
            CultureInfo culture = new CultureInfo("en-GB");

            var result = (from c in _context.Countries
                            where _context.Containers.Any(t => (t.CountryID == c.ID) &&
                            _context.Products.Any(p => (p.ContainerID == t.ID) &&
                            //_context.Policies.Any(l => (l.ProductID == p.ID) &&
                            _context.Claims.Any(m => m.ClaimNumber == claimId)))
                            select c.Tax);

            if (taxable && result != null)
            {
                decimal taxRate = Convert.ToDecimal(result.FirstOrDefault().ToString(), culture);
                taxAmount = amount * taxRate / 100;
            }

            return taxAmount;
        }

        public async Task<IActionResult> SetAuthorise(Guid policyId, int claimId, Guid Id, bool authorised)
        {
            Guid policyid = policyId;
            int claimid = claimId;
            bool authValue = authorised ? false : true;
            var userId = authValue ? this.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            var myParams = new object[] { authValue, userId, Id };

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE ClaimTransaction SET Authorised = {0}, AuthoriserID = {1} WHERE ID = {2}",
                parameters: myParams);

            return RedirectToAction("Index", new { policyId, claimId });
        }

        private string ProductName(Guid productId)
        {
            return _context.Products.SingleOrDefault(c => c.ID == productId).Name;
        }

        private bool InvoiceNumberExists(string invoiceNumber)
        {
            return _context.ClaimTransactions.Any(e => e.InvoiceNumber == invoiceNumber);
        }
    }
}
