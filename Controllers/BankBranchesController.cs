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
    public class BankBranchesController : Controller
    {
        private readonly InsurerDbContext _context;

        public BankBranchesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: BankBranches
        public async Task<IActionResult> Index(Guid bankId)
        {
            var bankbranches = await _context.BankBranches
                                .Include(b => b.Bank)
                                .AsNoTracking()
                                .Where(b => b.BankID == bankId)
                                .OrderBy(r => r.Name).ToListAsync();

            BankBranchesViewModel viewModel = new BankBranchesViewModel
            {
                BankID = bankId,
                BankName = BankName(bankId),
                BankBranches = bankbranches
            };
            return View(viewModel);
        }

        // GET: BankBranches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranches.SingleOrDefaultAsync(m => m.ID == id);
            if (bankBranch == null)
            {
                return NotFound();
            }

            return View(bankBranch);
        }

        // GET: BankBranches/Create
        public IActionResult Create(Guid bankId)
        {
            BankBranchViewModel viewModel = new BankBranchViewModel
            {
                BankID = bankId,
                BankName = BankName(bankId),
            };
            return View(viewModel);
        }

        // POST: BankBranches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankBranchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BankBranch bankBranch = new BankBranch();
                bankBranch = viewModel.BankBranch;
                bankBranch.ID = Guid.NewGuid();
                bankBranch.BankID = viewModel.BankID;
                _context.Add(bankBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { bankId = viewModel.BankID });
            }
            return View(viewModel);
        }

        // GET: BankBranches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranches.SingleOrDefaultAsync(m => m.ID == id);
            if (bankBranch == null)
            {
                return NotFound();
            }
            ViewData["BankID"] = bankBranch.BankID;
            return View(bankBranch);
        }

        // POST: BankBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,BIC,BankID,Name,SwiftCode")] BankBranch bankBranch)
        {
            if (id != bankBranch.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankBranch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { bankid = bankBranch.BankID });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankBranchExists(bankBranch.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["BankID"] = bankBranch.BankID;
            return View(bankBranch);
        }

        // GET: BankBranches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranches.SingleOrDefaultAsync(m => m.ID == id);
            if (bankBranch == null)
            {
                return NotFound();
            }

            return View(bankBranch);
        }

        // POST: BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bankBranch = await _context.BankBranches.SingleOrDefaultAsync(m => m.ID == id);
            _context.BankBranches.Remove(bankBranch);
            await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { bankid = bankBranch.BankID });
        }

        private string BankName(Guid bankId)
        {
            return _context.Banks.SingleOrDefault(b => b.ID == bankId).Name;
        }

        private bool BankBranchExists(Guid id)
        {
            return _context.BankBranches.Any(e => e.ID == id);
        }
    }
}
