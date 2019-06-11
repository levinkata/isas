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
    public class RepairersController : Controller
    {
        private readonly InsurerDbContext _context;

        public RepairersController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Repairers
        public async Task<IActionResult> Index(int payeeClassId)
        {
            RepairersViewModel viewModel = new RepairersViewModel
            {
                PayeeClassID = payeeClassId,
                Repairers = await _context.Repairers
                                    .AsNoTracking()
                                    .OrderBy(r => r.Name)
                                    .ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Repairers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairer = await _context.Repairers.SingleOrDefaultAsync(m => m.ID == id);
            if (repairer == null)
            {
                return NotFound();
            }
            return View(repairer);
        }

        // GET: Repairers/Create
        public IActionResult Create(int payeeClassId)
        {
            Repairer repairer = new Repairer
            {
                PayeeClassID = payeeClassId
            };

            RepairerViewModel viewModel = new RepairerViewModel
            {
                Repairer = repairer
            };
            return View(viewModel);
        }

        // POST: Repairers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Repairer repairer = new Repairer();
                repairer = viewModel.Repairer;
                repairer.ID = Guid.NewGuid();
                _context.Add(repairer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { payeeclassId = viewModel.Repairer.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: Repairers/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            RepairerViewModel viewModel = new RepairerViewModel
            {
                Repairer = await _context.Repairers.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: Repairers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RepairerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repairer repairer = viewModel.Repairer;
                    _context.Update(repairer);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { repairer.ID, repairer.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Repairer.PayeeClassID });
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

        // GET: Repairers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairer = await _context.Repairers.SingleOrDefaultAsync(m => m.ID == id);
            if (repairer == null)
            {
                return NotFound();
            }

            return View(repairer);
        }

        // POST: Repairers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var repairer = await _context.Repairers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Repairers.Remove(repairer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RepairerExists(Guid id)
        {
            return _context.Repairers.Any(e => e.ID == id);
        }
    }
}
