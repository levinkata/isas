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
    public class LossAdjustersController : Controller
    {
        private readonly InsurerDbContext _context;

        public LossAdjustersController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: LossAdjusters
        public async Task<IActionResult> Index(int payeeClassId)
        {
            LossAdjustersViewModel viewModel = new LossAdjustersViewModel
            {
                PayeeClassID = payeeClassId,
                LossAdjusters = await _context.LossAdjusters
                                    .AsNoTracking()
                                    .OrderBy(l => l.Name)
                                    .ToListAsync()
            };
            return View(viewModel);
        }

        // GET: LossAdjusters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lossAdjuster = await _context.LossAdjusters
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(m => m.ID == id);

            return View(lossAdjuster);
        }

        // GET: LossAdjusters/Create
        public IActionResult Create(int payeeClassId)
        {
            LossAdjuster lossAdjuster = new LossAdjuster
            {
                PayeeClassID = payeeClassId
            };

            LossAdjusterViewModel viewModel = new LossAdjusterViewModel
            {
                LossAdjuster = lossAdjuster
            };
            return View(viewModel);
        }

        // POST: LossAdjusters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LossAdjusterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                LossAdjuster lossAdjuster = new LossAdjuster();
                lossAdjuster = viewModel.LossAdjuster;
                lossAdjuster.ID = Guid.NewGuid();
                _context.Add(lossAdjuster);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { payeeclassId = viewModel.LossAdjuster.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: LossAdjusters/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            LossAdjusterViewModel viewModel = new LossAdjusterViewModel
            {
                LossAdjuster = await _context.LossAdjusters.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: LossAdjusters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LossAdjusterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    LossAdjuster lossAdjuster = new LossAdjuster();
                    lossAdjuster = viewModel.LossAdjuster;
                    _context.Update(lossAdjuster);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { lossAdjuster.ID, lossAdjuster.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.LossAdjuster.PayeeClassID });
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

        // GET: LossAdjusters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lossAdjuster = await _context.LossAdjusters.SingleOrDefaultAsync(m => m.ID == id);
            if (lossAdjuster == null)
            {
                return NotFound();
            }

            return View(lossAdjuster);
        }

        // POST: LossAdjusters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lossAdjuster = await _context.LossAdjusters.SingleOrDefaultAsync(m => m.ID == id);
            _context.LossAdjusters.Remove(lossAdjuster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LossAdjusterExists(Guid id)
        {
            return _context.LossAdjusters.Any(e => e.ID == id);
        }
    }
}
