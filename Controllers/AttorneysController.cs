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
    public class AttorneysController : Controller
    {
        private readonly InsurerDbContext _context;

        public AttorneysController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Attorneys
        public async Task<IActionResult> Index(int payeeClassId)
        {
            AttorneysViewModel viewModel = new AttorneysViewModel
            {
                PayeeClassID = payeeClassId,
                Attorneys = await _context.Attorneys
                                    .AsNoTracking()
                                    .OrderBy(a => a.Name)
                                    .ToListAsync()
            };
            return View(viewModel);
        }
        
        // GET: Attorneys/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys
                                .AsNoTracking()
                                .SingleOrDefaultAsync(m => m.ID == id);

            if (attorney == null)
            {
                return NotFound();
            }

            return View(attorney);
        }

        // GET: Attorneys/Create
        public IActionResult Create(int payeeclassId)
        {
            Attorney attorney = new Attorney
            {
                PayeeClassID = payeeclassId
            };

            AttorneyViewModel viewModel = new AttorneyViewModel
            {
                Attorney = attorney
            };
            return View(viewModel);
        }

        // POST: Attorneys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttorneyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Attorney attorney = new Attorney
                {
                    ID = Guid.NewGuid()
                };
                attorney = viewModel.Attorney;

                _context.Add(attorney);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { payeeclassId = viewModel.Attorney.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: Attorneys/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            AttorneyViewModel viewModel = new AttorneyViewModel
            {
                Attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: Attorneys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AttorneyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Attorney attorney = new Attorney();
                    attorney = viewModel.Attorney;
                    _context.Update(attorney);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { attorney.ID, attorney.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Attorney.PayeeClassID });
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

        // GET: Attorneys/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.ID == id);
            if (attorney == null)
            {
                return NotFound();
            }

            return View(attorney);
        }

        // POST: Attorneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.ID == id);
            _context.Attorneys.Remove(attorney);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttorneyExists(Guid id)
        {
            return _context.Attorneys.Any(e => e.ID == id);
        }
    }
}
