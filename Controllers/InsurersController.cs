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
    public class InsurersController : Controller
    {
        private readonly InsurerDbContext _context;

        public InsurersController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Insurers
        public async Task<IActionResult> Index(int payeeClassId)
        {
            InsurersViewModel viewModel = new InsurersViewModel
            {
                PayeeClassID = payeeClassId,
                Insurers = await _context.Insurers
                                .AsNoTracking()
                                .OrderBy(i => i.Name)
                                .ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Insurers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurer = await _context.Insurers
                                .AsNoTracking()
                                .SingleOrDefaultAsync(m => m.ID == id);

            if (insurer == null)
            {
                return NotFound();
            }
            return View(insurer);
        }

        // GET: Insurers/Create
        public IActionResult Create(int payeeClassId)
        {
            Insurer insurer = new Insurer
            {
                PayeeClassID = payeeClassId
            };

            InsurerViewModel viewModel = new InsurerViewModel
            {
                Insurer = insurer
            };
            return View(viewModel);
        }

        // POST: Insurers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsurerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Insurer insurer = new Insurer();
                insurer = viewModel.Insurer;
                insurer.ID = Guid.NewGuid();
                _context.Add(insurer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { payeeclassId = viewModel.Insurer.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: Insurers/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            InsurerViewModel viewModel = new InsurerViewModel
            {
                Insurer = await _context.Insurers.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: Insurers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InsurerViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Insurer insurer = new Insurer();
                    insurer = viewModel.Insurer;
                    _context.Update(insurer);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { insurer.ID, insurer.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Insurer.PayeeClassID });
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

        // GET: Insurers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurer = await _context.Insurers.SingleOrDefaultAsync(m => m.ID == id);
            if (insurer == null)
            {
                return NotFound();
            }

            return View(insurer);
        }

        // POST: Insurers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var insurer = await _context.Insurers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Insurers.Remove(insurer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InsurerExists(Guid id)
        {
            return _context.Insurers.Any(e => e.ID == id);
        }
    }
}
