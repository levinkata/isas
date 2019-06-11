using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    public class PayablesController : Controller
    {
        private IHostingEnvironment hostingEnv;
        private readonly InsurerDbContext _context;

        public PayablesController(InsurerDbContext context, IHostingEnvironment env)
        {
            _context = context;
            hostingEnv = env;
        }

        // GET: Payables
        public async Task<IActionResult> Index(Guid productId)
        {
            int paymentTypeId = _context.PaymentTypes.FirstOrDefault().ID;

            var payables = await _context.Payables
                                .Include(c => c.ClaimTransaction)
                                    .ThenInclude(p => p.Payee)
                                .Include(p => p.PaymentType)
                                .AsNoTracking()
                                .Where(p => p.ProductID == productId &&
                                p.PaymentTypeID == paymentTypeId)
                                .OrderBy(d => d.PayableDate)
                                .ToListAsync();

            PayablesViewModel viewModel = new PayablesViewModel
            {
                ProductID = productId,
                Payables = payables,
                PaymentTypeID = _context.PaymentTypes
                                        .AsNoTracking()
                                        .FirstOrDefault().ID,
                PaymentTypeList = new SelectList(await _context.PaymentTypes
                                                    .AsNoTracking()
                                                    .ToListAsync(), "ID", "Name", _context.PaymentTypes.FirstOrDefault().ID)
            };
            return View(viewModel);
        }
        
        public async Task<IActionResult> PopulateTable(Guid productId, int paymentTypeId)
        {
            //  Get Payee using ThenInclude on ClaimTransaction
            var data = await _context.Payables
                                .Include(c => c.ClaimTransaction)
                                    .ThenInclude(p => p.Payee)
                                .Include(t => t.PaymentType)
                                .Where(p => p.ProductID == productId &&
                                p.PaymentTypeID == paymentTypeId)
                                .OrderBy(d => d.PayableDate)
                                .Select(r => new
                                {
                                    r.Reference,
                                    r.PayableDate,
                                    PaymentType = r.PaymentType.Name,
                                    Payee = r.ClaimTransaction.Select(c => c.Payee.Name).Distinct(),
                                    r.Amount,
                                    r.BatchNumber
                                }).ToListAsync();

            return Json(data);
        }

        // GET: Payables/ProcessPayments
        public async Task<IActionResult> ProcessPayments(Guid productId,
                            string errReference, string errBankAccounts)
        {
            if (!string.IsNullOrEmpty(errReference))
                ViewData["ErrReference"] = errReference;

            if (!string.IsNullOrEmpty(errBankAccounts))
                ViewData["ErrBankAccounts"] = errBankAccounts;

            var myParam = productId;

            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM ChequeTemp WHERE ProductID = {0}",
                                    parameters: myParam);

            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM ChequeSummaryTemp WHERE ProductID = {0}",
                                    parameters: myParam);

            string query = "SELECT CT.ID AS ID, PD.ID AS ProductID, CT.ClaimID AS ClaimID, " +
                            "PY.ID AS PayeeID, PY.Name AS Payee, CT.InvoiceNumber AS InvoiceNumber, " +
                            "AC.AccountCode AS AccountCode, AF.Name AS Affected, " +
                            "CT.Authorised AS Authorised, CT.Amount AS Amount, " +
                            "CN.LastName + ' ' + CN.FirstName AS Client, IR.Name AS Insurer, " +
                            "PD.Name AS Product " +
                            "FROM ClaimTransaction AS CT INNER JOIN Payee AS PY ON CT.PayeeID = PY.ID " +
                            "INNER JOIN Claim AS CL ON CT.ClaimID = CL.ID " +
                            "INNER JOIN Policy AS PL ON CL.PolicyID = PL.ID " +
                            "INNER JOIN Client AS CN ON PL.ClientID = CN.ID " +
                            "INNER JOIN Affected AS AF ON CT.AffectedID = AF.ID " +
                            "INNER JOIN AccountChart AS AC ON CT.AccountID = AC.ID " +
                            "INNER JOIN Insurer AS IR ON PL.InsurerID = IR.ID " +
                            "INNER JOIN Product PD ON PL.ProductID = PD.ID " +
                            "WHERE CT.Authorised = 1 AND CT.Amount > 0 " +
                            "AND CT.HoldForPayment = 0 AND PassForPayment = 1 " +
                            "AND PayableID IS NULL AND PD.ID = {0} " +
                            "ORDER BY PY.Name";

            var chequetransactions = await _context.ChequeTemps
                                        .FromSql(query, myParam)
                                        .AsNoTracking()
                                        .ToListAsync();

            foreach (ChequeTemp c in chequetransactions)
            {
                _context.ChequeTemps.Add(c);
            }
            _context.SaveChanges();

            string query1 = "SELECT PY.ID AS ID, PD.ID AS ProductID, PY.Name AS Payee, " +
                            "NULL AS PostalAddress, NULL AS City, " +
                            "SUM(CT.Amount) AS Amount, COUNT(*) AS PayeeCount " +
                            "FROM ClaimTransaction AS CT INNER JOIN Payee AS PY ON CT.PayeeID = PY.ID " +
                            "INNER JOIN Claim AS CL ON CT.ClaimID = CL.ID " +
                            "INNER JOIN Policy AS PL ON CL.PolicyID = PL.ID " +
                            "INNER JOIN Client AS CN ON PL.ClientID = CN.ID " +
                            "INNER JOIN Affected AS AF ON CT.AffectedID = AF.ID " +
                            "INNER JOIN AccountChart AS AC ON CT.AccountID = AC.ID " +
                            "INNER JOIN Insurer AS IR ON PL.InsurerID = IR.ID " +
                            "INNER JOIN Product PD ON PL.ProductID = PD.ID " +
                            "WHERE CT.Authorised = 1 AND CT.Amount > 0 " +
                            "AND CT.HoldForPayment = 0 AND PassForPayment = 1 " +
                            "AND PayableID IS NULL AND PD.ID = {0} " +
                            "GROUP BY PY.ID, PD.ID, PY.Name " +
                            "ORDER BY PY.Name";

            var chequesummary = await _context.ChequeSummaryTemps
                            .FromSql(query1, myParam)
                            .AsNoTracking()
                            .ToListAsync();

            int rowCount = chequesummary.Count();

            object[,] bankaccounts = new object[rowCount, 5];
            int i = 0;
            bool allaccounts = true;

            foreach (ChequeSummaryTemp c in chequesummary)
            {
                //  Get PayeeID and check if Payee has Bank Account Number
                //  Then populate the BankAccount Array
                List<string> accountnumber = GetBankAccount(c.PayeeID);

                bankaccounts[i, 0] = c.PayeeID;
                bankaccounts[i, 1] = c.Payee;
                bankaccounts[i, 2] = accountnumber[0];      //  Account Number
                bankaccounts[i, 3] = accountnumber[1];      //  BIC
                bankaccounts[i, 4] = accountnumber[2];      //  Bank

                allaccounts = (accountnumber.Count == 0) ? false : true;

                //  Get Payee Address
                List<string> PayeeAddress = GetPayeeAddress(c.PayeeID);
                c.PostalAddress = PayeeAddress[0];
                c.City = PayeeAddress[1];

                _context.ChequeSummaryTemps.Add(c);
                i++;
            }
            _context.SaveChanges();

            PaymentProcessingViewModel viewModel = new PaymentProcessingViewModel
            {
                ProductID = productId,
                ProductName = ProductName(productId),
                ChequeTemps = chequetransactions,
                ChequeSummaryTemps = chequesummary,
                BankAccounts = bankaccounts,
                AllAccounts = allaccounts,
                PaymentTypeList = new SelectList(_context.PaymentTypes, "ID", "Name", _context.PaymentTypes.FirstOrDefault().ID),
                PaymentTypeID = _context.PaymentTypes.FirstOrDefault().ID
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayments(PaymentProcessingViewModel viewModel)
        {
            string ReferenceNumber = viewModel.ReferenceNumber;
            bool allaccounts = viewModel.AllAccounts;

            if (string.IsNullOrEmpty(ReferenceNumber))
            {
                return RedirectToAction("ProcessPayments", new { productId = viewModel.ProductID,
                    errReference = "Process cannot continue. Please enter value."
                });
            };
            
            if (!allaccounts && (viewModel.PaymentTypeID != 1 && viewModel.PaymentTypeID != 3))
            {
                return RedirectToAction("ProcessPayments", new
                {
                    productId = viewModel.ProductID,
                    errBankAccounts = "Process cannot continue. Please ensure that all payees have account numbers."
                });
            };

            if (ReferenceNumber != null)
            {
                const int BufferSize = 4096;
                int paymentType = viewModel.PaymentTypeID;

                var todaydate = DateTime.Now.ToString("yyyyMMddHHmmss");

                string dy = todaydate.Substring(6, 2);
                string mn = todaydate.Substring(4, 2);
                string yr = todaydate.Substring(0, 4);
                string hr = todaydate.Substring(8, 2);
                string mi = todaydate.Substring(10, 2);
                string sc = todaydate.Substring(12, 2);

                string prefix = "";

                switch (paymentType)
                {
                    case 1:         //  Cash
                        prefix = "CSH";
                        break;
                    case 2:         //  EFT
                        prefix = "EFT";
                        break;
                    case 3:         //  Cheque
                        prefix = "CHQ";
                        break;
                    case 4:         //  Direct Debit
                        prefix = "DDR";
                        break;
                    case 5:         //  Bank Transfer
                        prefix = "BTR";
                        break;
                    default:
                        break;
                }

                var filename = prefix + "-File-" + yr + mn + dy + hr + mi + sc + ".txt";
                var filePath = hostingEnv.WebRootPath + $@"\BankFiles\{filename}";

                var cheques = await _context.ChequeSummaryTemps.ToListAsync();
                var chequetransactions = await _context.ChequeTemps.ToListAsync();
                
                BatchNumbers BatchNumberGen = new BatchNumbers(_context);
                var BatchNumber = BatchNumberGen.GetBatchNumber();

                int chequenumber = 0;

                if (paymentType == 3)
                {
                    chequenumber = int.Parse(viewModel.ReferenceNumber);
                    ReferenceNumber = chequenumber.ToString();
                }
                else
                {
                    ReferenceNumber = viewModel.ReferenceNumber;
                };


                Guid productId = viewModel.ProductID;
                int paymentTypeId = viewModel.PaymentTypeID;
                Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Guid payableId = Guid.Empty;

                var myParams = new object[] { productId, ReferenceNumber, BatchNumber };

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read, BufferSize, true))
                {
                    Int32 offset = 0;
                    string refnumberVar = string.Empty;
                    string text = "Payment Transactions\r\n";
                    text += "=====================\r\n";
                    byte[] buffer = Encoding.Unicode.GetBytes(text);
                    await fs.WriteAsync(buffer, offset, buffer.Length);

                    decimal BulkAmount = cheques.Sum(a => a.Amount);
                    foreach (ChequeSummaryTemp c in cheques)
                    {
                        Guid payeeId = c.PayeeID;

                        //  This string attempts to create the presumed record format as will be determined by the paying
                        //  institution. This string assumes that the output will be a comma-separated ascii file in the 
                        //  given column order.
                        if (paymentType == 1 || paymentType == 3)
                        {
                            text = ReferenceNumber + "," + c.Amount.ToString() + "," +
                                    DateTime.Now.ToString("dd/MM/yyyy") + "," + c.Payee + "," +
                                    c.PostalAddress + "," + c.City;
                        }
                        else if (paymentType == 2 || paymentType == 4 || paymentType == 2)
                        {
                            //  Get Payee Bank Account Details
                            var bankaccountdetail = GetBankDetails(c.PayeeID);
                            text = ReferenceNumber + "," + bankaccountdetail + "," + c.Amount.ToString() + "," +
                                    DateTime.Now.ToString("dd/MM/yyyy") + "," + c.Payee + "," +
                                    c.PostalAddress + "," + c.City;
                        };

                        buffer = Encoding.Unicode.GetBytes(text + "\r\n");
                        await fs.WriteAsync(buffer, offset, buffer.Length);

                        if (!ReferenceNumber.Equals(refnumberVar))
                        {
                            refnumberVar = ReferenceNumber;
                            decimal FinalAmount = (paymentType == 3) ? c.Amount : BulkAmount;

                            var payableParams = new object[] { Guid.NewGuid(), productId, ReferenceNumber, DateTime.Now,
                                                           paymentTypeId, FinalAmount, BatchNumber, false, null, null,
                                                           null, DateTime.Now, currentUserId, null, null };

                            await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO Payable (ID, ProductID, Reference, PayableDate, PaymentTypeID, Amount, " +
                                            "BatchNumber, Void, VoidReason, Remarks, PayableExportID, DateAdded, AddedBy, " +
                                            "DateModified, ModifiedBy) " +
                                            "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                                            parameters: payableParams);

                            //  Get Payable ID
                            payableId = GetPayableId(ReferenceNumber);
                        };
                        
                        foreach (ChequeTemp t in chequetransactions)
                        {
                            if (t.PayeeID == payeeId)
                            {
                                var transParams = new object[] { t.ID, payableId };

                                await _context.Database.ExecuteSqlCommandAsync(
                                                "UPDATE ClaimTransaction SET PayableID = {1} " +
                                                "WHERE ID = {0}",
                                                parameters: transParams);
                            }
                        }

                        chequenumber++;

                        if (paymentType == 3)
                        {
                            refnumberVar = chequenumber.ToString();
                            ReferenceNumber = refnumberVar;
                        }
                        else
                        {
                            refnumberVar = ReferenceNumber;
                        };
                    };
                    fs.Flush();
                }

                var batchParams = new object[] { BatchNumber };

                await _context.Database.ExecuteSqlCommandAsync(
                                        "INSERT INTO BatchNumberGenerator(BatchNumber) " +
                                        "Values ({0})",
                                        parameters: batchParams);

                // Generete Payment File [Done]
                // Then insert into Payable and update ClaimTransaction tables
                // Delete ChequeTemp and ChequeSummaryTemp records

                var myParam = productId;

                await _context.Database.ExecuteSqlCommandAsync(
                                        "DELETE FROM ChequeTemp WHERE ProductID = {0}",
                                        parameters: myParam);

                await _context.Database.ExecuteSqlCommandAsync(
                                        "DELETE FROM ChequeSummaryTemp WHERE ProductID = {0}",
                                        parameters: myParam);
            }

            return RedirectToAction("ProcessPayments", new { productId = viewModel.ProductID });
        }

        public async Task<IActionResult> Payables (Guid productId)
        {
            var payables = await (_context.ClaimTransactions
                                .Include(c => c.Account)
                                .Include(c => c.Affected)
                                .Include(c => c.Claim)
                                .Include(c => c.Payee)
                                .Include(c => c.TransactionType)
                                .AsNoTracking()
                                .Where(p => // p.Claim.Policy.ProductID == productId &&
                                p.Authorised == true &&
                                p.PassForPayment == 1)
                                .OrderBy(t => t.TransactionNumber)
                                .OrderBy(c => c.InvoiceDate)).ToListAsync();

            PayableViewModel viewModel = new PayableViewModel()
            {
                ProductID = productId,
                ClaimTransactions = payables
            };
            return View(viewModel);
        }

        // POST: Payables/PayablesConfirmed
        [HttpPost, ActionName("Payables")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayablesConfirmed(PayableViewModel viewModel)
        {
            // Make Paid and generate EFT file
            Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var payParam = new object[] { Guid.NewGuid(), viewModel.ProductID, viewModel.Payable.Reference,
                                          viewModel.Payable.PayableDate, viewModel.Payable.PaymentTypeID,
                                          viewModel.Payable.Amount, viewModel.Payable.BatchNumber,
                                          false, null, null, null, DateTime.Now, currentUserId, null, null };

            await _context.Database.ExecuteSqlCommandAsync(
                        "INSERT INTO Payable(ID, ProductID, Reference, PayableDate, PaymentTypeID, Amount, BatchNumber, " +
                        "Void, VoidReason, Remarks, PayableExportID, DateAdded, AddedBy, DateModified, ModifiedBy) " +
                        "Values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                        parameters: payParam);

            Guid payableId = GetPayableId(viewModel.Payable.Reference);

            foreach (var c in viewModel.ClaimTransactions)
            {
                    var myParams = new object[] { c.ID, payableId };

                    await _context.Database.ExecuteSqlCommandAsync(
                        "UPDATE ClaimTransaction SET PayableID = {1} WHERE ID = {0}",
                        parameters: myParams);
            }

            return RedirectToAction("GeneratePayables", new { productId = viewModel.ProductID });
        }

        // GET: Payables/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payable = await _context.Payables
                .SingleOrDefaultAsync(m => m.ID == id);
            if (payable == null)
            {
                return NotFound();
            }

            return View(payable);
        }

        // GET: Payables/Create
        public IActionResult Create()
        {
            ViewData["PayableExportID"] = new SelectList(_context.PayableExports, "ID", "Name");
            return View();
        }

        // POST: Payables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Reference,PayableDate,PaymentTypeID,Amount,BatchNumber,Void,VoidReason,Remarks,PayableExportID")] Payable payable)
        {
            if (ModelState.IsValid)
            {
                payable.ID = Guid.NewGuid();
                _context.Add(payable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PayableExportID"] = new SelectList(_context.PayableExports, "ID", "Name", payable.PayableExportID);
            return View(payable);
        }

        // GET: Payables/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payable = await _context.Payables.SingleOrDefaultAsync(m => m.ID == id);
            if (payable == null)
            {
                return NotFound();
            }
            ViewData["PayableExportID"] = new SelectList(_context.PayableExports, "ID", "Name", payable.PayableExportID);
            return View(payable);
        }

        // POST: Payables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Reference,PayableDate,PaymentTypeID,Amount,BatchNumber,Void,VoidReason,Remarks,PayableExportID")] Payable payable)
        {
            if (id != payable.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayableExists(payable.ID))
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
            ViewData["PayableExportID"] = new SelectList(_context.PayableExports, "ID", "Name", payable.PayableExportID);
            return View(payable);
        }

        // GET: Payables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payable = await _context.Payables
                .SingleOrDefaultAsync(m => m.ID == id);
            if (payable == null)
            {
                return NotFound();
            }

            return View(payable);
        }

        // POST: Payables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payable = await _context.Payables.SingleOrDefaultAsync(m => m.ID == id);
            _context.Payables.Remove(payable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Payables/Approve
        public async Task<IActionResult> Approve(Guid productId)
        {
            HttpContext.Session.SetString("ProductID", productId.ToString());

            var payablesdue = await (_context.ClaimTransactions
                                    .Include(c => c.Account)
                                    .Include(c => c.Affected)
                                    .Include(c => c.Claim)
                                    .Include(c => c.Payee)
                                    .Include(c => c.TransactionType)
                                    .AsNoTracking()
                                    .Where(p => // p.Claim.Policy.ProductID == productId &&
                                    p.Authorised == true &&
                                    p.PassForPayment == 0)
                                    .OrderBy(t => t.TransactionNumber)
                                    .OrderBy(c => c.InvoiceDate)).ToListAsync();

            PayableViewModel viewModel = new PayableViewModel()
            {
                ProductID = productId,
                ProductName = ProductName(productId),
                ClaimTransactions = payablesdue
            };
            return View(viewModel);
        }

        public async Task<IActionResult> PassForPayment(Guid productId, Guid Id)
        {
            Guid _productId = productId;
            var myParams = new object[] { Id, 1 };

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE ClaimTransaction SET PassForPayment = {1} WHERE ID = {0}",
                parameters: myParams);

            return RedirectToAction("Approve", new { productId = _productId });
        }

        public async Task<IActionResult> RemoveFromPayment(Guid productId, Guid Id)
        {
            Guid _productId = productId;
            var myParams = new object[] { Id, 0 };

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE ClaimTransaction SET PassForPayment = {1} WHERE ID = {0}",
                parameters: myParams);

            return RedirectToAction("ProcessPayments", new { productId = _productId });
        }

        // POST: Payables/ApproveConfirmed
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmed(PayableViewModel viewModel)
        {
            //bool authValue = authorised ? false : true;
            //Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var c in viewModel.ClaimTransactions)
            {
                var myParams = new object[] { c.ID, 1 };

                await _context.Database.ExecuteSqlCommandAsync(
                    "UPDATE ClaimTransaction SET PassForPayment = {1} WHERE ID = {0}",
                    parameters: myParams);
            }

            return RedirectToAction("Approve", new { productId = viewModel.ProductID });
        }

        private List<string> GetBankAccount(Guid payeeId)
        {
            List<string> AccountDetails = new List<string>();
            var accountNumber = string.Empty;
            var bic = string.Empty;
            var bankName = string.Empty;

            var result = _context.PayeeBankAccounts
                                .Include(b => b.BankAccount)
                                    .ThenInclude(r => r.BankBranch)
                                        .ThenInclude(k => k.Bank)
                                .SingleOrDefault(r => r.PayeeID == payeeId);

            if (result != null)
            {
                accountNumber = result.BankAccount.AccountNumber;
                bic = result.BankAccount.BankBranch.BIC;
                bankName = result.BankAccount.BankBranch.Bank.Name;
            }
            AccountDetails.Add(accountNumber);
            AccountDetails.Add(bic);
            AccountDetails.Add(bankName);
            return AccountDetails;
        }
        
        private string GetBankDetails (Guid payeeId)
        {
            List<string> bankdetails = new List<string>();
            string bankdetailsline = string.Empty + "," + string.Empty;

            var result = _context.PayeeBankAccounts
                            .Include(b => b.BankAccount)
                                .ThenInclude(r => r.BankBranch)
                            .SingleOrDefault(r => r.PayeeID == payeeId);

            if (result != null)
            {
                bankdetails.Add(result.BankAccount.BankBranch.BIC);
                bankdetails.Add(result.BankAccount.AccountNumber);

                // Join strings into one CSV line.
                bankdetailsline = string.Join(",", bankdetails.ToArray());
            }
            return bankdetailsline;
        }

        private List<string> GetPayeeAddress(Guid payeeId)
        {
            List<string> payeeaddress = new List<string>();
            var postalAddress = string.Empty;
            var city = string.Empty;

            var payee = _context.Payees
                            .SingleOrDefault(r => r.ID == payeeId);

            if (payee != null)
            {
                var payeeClassId = payee.PayeeClassID;
                var payeeItemId = payee.PayeeItemID;

                List<Address> address = new List<Address>();

                switch (payeeClassId)
                {
                    case 1:             //  Attorney
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID && 
                                       _context.Attorneys.Any(t => t.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 2:             //  Bank
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.Banks.Any(b => b.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 3:             //  Client
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.Clients.Any(c => c.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 4:             //  Insurer
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.Insurers.Any(i => i.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 5:             //  Loss Adjuster
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.LossAdjusters.Any(l => l.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 6:             //  Repairer
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.Repairers.Any(r => r.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 7:             //  Third Party
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.ThirdParties.Any(t => t.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    case 8:             //  Tracing Agent
                        address = (from a in _context.Addresses
                                   where _context.AddressAssignments.Any(d => d.AddressID == a.ID &&
                                       _context.TracingAgents.Any(t => t.ID == d.ItemID))
                                   select a).ToList();
                        break;
                    default:
                        break;
                }

                postalAddress = address.FirstOrDefault().PostalAddress;
                city = address.FirstOrDefault().City;


            }
            payeeaddress.Add(postalAddress);
            payeeaddress.Add(city);
            return payeeaddress;
        }

        private string ProductName(Guid productId)
        {
            return _context.Products.SingleOrDefault(c => c.ID == productId).Name;
        }

        private Guid GetPayableId(string reference)
        {
            return _context.Payables.SingleOrDefault(r => r.Reference == reference).ID;
        }

        private bool PayableExists(Guid id)
        {
            return _context.Payables.Any(e => e.ID == id);
        }
    }
}
