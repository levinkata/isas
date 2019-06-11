using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class BanksController : Controller
    {
        private readonly InsurerDbContext _context;

        public BanksController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Banks
        public async Task<IActionResult> Index(int payeeClassId)
        {
            BanksViewModel viewModel = new BanksViewModel
            {
                PayeeClassID = payeeClassId,
                Banks = await _context.Banks
                                .AsNoTracking()
                                .OrderBy(b => b.Name)
                                .ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Banks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.SingleOrDefaultAsync(m => m.ID == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }


        // GET: Banks/Create
        public IActionResult Create(int payeeclassId)
        {
            Bank bank = new Bank
            {
                PayeeClassID = payeeclassId
            };

            BankViewModel viewModel = new BankViewModel
            {
                Bank = bank
            };
            return View(viewModel);
        }

        // POST: Banks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Bank bank = new Bank();
                bank = viewModel.Bank;
                bank.ID = Guid.NewGuid();
                _context.Add(bank);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { payeeclassId = viewModel.Bank.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: Banks/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            BankViewModel viewModel = new BankViewModel
            {
                Bank = await _context.Banks.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: Banks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    Bank bank = new Bank();
                    bank = viewModel.Bank;
                    _context.Update(bank);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { bank.ID, bank.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Bank.PayeeClassID });
                }
                catch (DbUpdateException ex)
                {
                    var errorMsg = ex.InnerException.Message.ToString();

                    viewModel.ErrMsg = errorMsg;
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }
            }
            return View(viewModel);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.SingleOrDefaultAsync(m => m.ID == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bank = await _context.Banks.SingleOrDefaultAsync(m => m.ID == id);
            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BankExists(Guid id)
        {
            return _context.Banks.Any(e => e.ID == id);
        }
    }
}
