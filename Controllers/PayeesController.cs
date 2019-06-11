using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class PayeesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PayeesController(InsurerDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> AddBankAccount(Guid payeeId)
        {
            var banks = await _context.Banks.ToListAsync();

            Guid bankId = banks.FirstOrDefault().ID;
            var bankbranches = await _context.BankBranches
                                    .Where(b => b.BankID == bankId)
                                    .OrderBy(n => n.Name)
                                    .ToListAsync();

            PayeeBankAccountViewModel viewModel = new PayeeBankAccountViewModel
            {
                PayeeID = payeeId,
                BankList = new SelectList(banks, "ID", "Name", banks.FirstOrDefault()),
                BankBranchList = new SelectList(bankbranches, "ID", "Name", bankbranches.FirstOrDefault())
            };
            return View(viewModel);
        }

        // POST: Payees/AddBankAccount/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBankAccount(PayeeBankAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BankAccount bankaccount = viewModel.BankAccount;
                PayeeBankAccount payeebankaccount = new PayeeBankAccount();

                bankaccount.ID = Guid.NewGuid();
                _context.Add(bankaccount);
                await _context.SaveChangesAsync();

                payeebankaccount.BankAccountID = bankaccount.ID;
                payeebankaccount.PayeeID = viewModel.PayeeID;
                _context.Add(payeebankaccount);
                await _context.SaveChangesAsync();

                //Guid payeeItemId = GetPayeeItemId(payeebankaccount.PayeeID);

                return RedirectToAction("PayeeBankAccounts", new { payeeId = viewModel.PayeeID });
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

        // GET: Payees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payees.Include(c => c.PayeeClass).OrderBy(l => l.Name).ToListAsync());
        }


        public async Task<IActionResult> SelectPayee(int claimNumber)
        {
            var payeeclasses = await (from c in _context.PayeeClasses
                                      orderby c.Name
                                      select c).ToListAsync();

            SelectedPayee viewModel = new SelectedPayee
            {
                ClaimNumber = claimNumber,
                PayeeClassList = new SelectList(payeeclasses, "ID", "Name", payeeclasses.FirstOrDefault())
            };
            return View(viewModel);
        }


        // POST: Premiums/SelectPayee/5
        [HttpPost, ActionName("SelectPayee")]
        [ValidateAntiForgeryToken]
        public IActionResult SelectPayeeConfirmed(SelectedPayee selectedpayee)
        {
            int payeeclassId = selectedpayee.Payee.PayeeClassID;

            if (ModelState.IsValid)
            {
                string classController = "";

                switch (payeeclassId)
                {
                    case 1:
                        classController = "Attorneys";
                        break;
                    case 2:
                        classController = "Banks";
                        break;
                    case 3:
                        classController = "Clients";
                        break;
                    case 4:
                        classController = "Insurers";
                        break;
                    case 5:
                        classController = "LossAdjusters";
                        break;
                    case 6:
                        classController = "Repairers";
                        break;
                    case 7:
                        classController = "ThirdParties";
                        break;
                    case 8:
                        classController = "TracingAgents";
                        break;
                    default:
                        classController = "";
                        break;
                }

                return RedirectToAction("Index", classController,
                    new {payeeclassid = payeeclassId, claimid = selectedpayee.ClaimNumber });

            }
            return View(selectedpayee);
        }

        public async Task<IActionResult> PayeeBankAccounts(Guid payeeId)
        {
            //Guid payeeId = GetPayeeId(payeeItemId);
            PayeeBankAccountsViewModel viewModel = new PayeeBankAccountsViewModel
            {
                PayeeID = payeeId,
                BankAccounts = await (from b in _context.BankAccounts
                                     .Include(a => a.BankBranch)
                                        .ThenInclude(h => h.Bank)
                                      where _context.PayeeBankAccounts.Any(r => (r.BankAccountID == b.ID) && (r.PayeeID == payeeId))
                                      orderby b.BankBranch.Name
                                      select b).ToListAsync()
            };

            return View(viewModel);
        }

        // GET: Payees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payee = await _context.Payees.SingleOrDefaultAsync(m => m.ID == id);
            if (payee == null)
            {
                return NotFound();
            }

            return View(payee);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int payeeClassId, Guid payeeItemId, string payeeName)
        {
            if (ModelState.IsValid)
            {
                Payee payee = new Payee
                {
                    ID = Guid.NewGuid(),
                    PayeeClassID = payeeClassId,
                    PayeeItemID = payeeItemId,
                    Name = payeeName
                };
                _context.Add(payee);
                await _context.SaveChangesAsync();
                UpdatePayeeItem(payeeClassId, payeeItemId);
            }
            
            string classController = "";
            switch (payeeClassId)
            {
                case 1:
                    classController = "Attorneys";
                    break;
                case 2:
                    classController = "Banks";
                    break;
                case 3:
                    classController = "Clients";
                    break;
                case 4:
                    classController = "Insurers";
                    break;
                case 5:
                    classController = "LossAdjusters";
                    break;
                case 6:
                    classController = "Repairers";
                    break;
                case 7:
                    classController = "ThirdParties";
                    break;
                case 8:
                    classController = "TracingAgents";
                    break;
                default:
                    classController = "";
                    break;
            }
            return RedirectToAction("Index", classController, new { payeeclassId = payeeClassId });
        }

        private Guid GetPayeeId(Guid payeeitemId)
        {
            var payee = _context.Payees.Single(m => m.PayeeItemID == payeeitemId);
            return payee.ID;
        }

        private Guid GetPayeeItemId(Guid payeeId)
        {
            var payee = _context.Payees.SingleOrDefault(m => m.ID == payeeId);
            return payee.PayeeItemID;
        }

        // GET: Payees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payee = await _context.Payees.SingleOrDefaultAsync(m => m.ID == id);
            if (payee == null)
            {
                return NotFound();
            }
            ViewData["PayeeClassID"] = new SelectList(_context.PayeeClasses, "ID", "Name", payee.PayeeClassID);
            return View(payee);
        }

        // POST: Payees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,PayeeClassID,PayeeItemID")] Payee payee)
        {
            if (id != payee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayeeExists(payee.ID))
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
            ViewData["PayeeClassID"] = new SelectList(_context.PayeeClasses, "ID", "Name", payee.PayeeClassID);
            return View(payee);
        }

        // GET: Payees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payee = await _context.Payees.SingleOrDefaultAsync(m => m.ID == id);
            if (payee == null)
            {
                return NotFound();
            }

            return View(payee);
        }

        // POST: Payees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payee = await _context.Payees.SingleOrDefaultAsync(m => m.ID == id);
            _context.Payees.Remove(payee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        void UpdatePayeeItem(int payeeClassId, Guid payeeItemId)
        {
            switch (payeeClassId)
            {
                case 1:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Attorney SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 2:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Bank SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 3:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Client SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 4:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Insurer SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 5:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE LossAdjuster SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 6:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE Repairer SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 7:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE ThirdParty SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
                case 8:
                    _context.Database.ExecuteSqlCommandAsync(
                                    "UPDATE TracingAgent SET Payable = 1 WHERE ID = {0}",
                                    parameters: payeeItemId);
                    break;
            }
        }

        private bool PayeeExists(Guid id)
        {
            return _context.Payees.Any(e => e.ID == id);
        }
    }
}
