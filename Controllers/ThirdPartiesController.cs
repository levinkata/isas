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
    public class ThirdPartiesController : Controller
    {
        private readonly InsurerDbContext _context;

        public ThirdPartiesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ThirdParties
        public async Task<IActionResult> Index(int payeeClassId)
        {
            ThirdPartiesViewModel viewModel = new ThirdPartiesViewModel
            {
                PayeeClassID = payeeClassId,
                ThirdParties = await _context.ThirdParties.AsNoTracking().OrderBy(t => t.LastName).ToListAsync()
            };
            return View(viewModel);
        }

        // GET: ThirdParties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thirdParty = await _context.ThirdParties
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(m => m.ID == id);

            if (thirdParty == null)
            {
                return NotFound();
            }

            return View(thirdParty);
        }

        // GET: ThirdParties/Create
        public IActionResult Create(int payeeclassId)
        {
            ThirdParty thirdParty = new ThirdParty
            {
                PayeeClassID = payeeclassId
            };

            ThirdPartyViewModel viewModel = new ThirdPartyViewModel
            {
                ThirdParty = thirdParty
            };
            return View(viewModel);
        }

        // POST: ThirdParties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThirdPartyViewModel viewModel)
        {
            var idNumber = viewModel.ThirdParty.IDNumber;
            try
            {
                if (ModelState.IsValid)
                {
                    ThirdParty thirdParty = new ThirdParty();
                    thirdParty = viewModel.ThirdParty;
                    thirdParty.ID = Guid.NewGuid();
                    _context.Add(thirdParty);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { payeeclassId = viewModel.ThirdParty.PayeeClassID });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                if (errorMsg.Contains("IX_ThirdParty_IDNumber"))
                    viewModel.ErrMsg = $"Duplicate ID Number {idNumber} exists.";
                else
                    viewModel.ErrMsg = errorMsg;

                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            return View(viewModel);
        }

        // GET: ThirdParties/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            ThirdPartyViewModel viewModel = new ThirdPartyViewModel
            {
                ThirdParty = await _context.ThirdParties.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: ThirdParties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ThirdPartyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ThirdParty thirdParty = viewModel.ThirdParty;
                    _context.Update(thirdParty);
                    await _context.SaveChangesAsync();

                    var FullName = (thirdParty.FirstName == null) ? thirdParty.LastName : thirdParty.FirstName + ' ' + thirdParty.LastName;
                    var payeeParams = new object[] { thirdParty.ID, FullName };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.ThirdParty.PayeeClassID });
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

        // GET: ThirdParties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thirdParty = await _context.ThirdParties.SingleOrDefaultAsync(m => m.ID == id);
            if (thirdParty == null)
            {
                return NotFound();
            }

            return View(thirdParty);
        }

        // POST: ThirdParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var thirdParty = await _context.ThirdParties.SingleOrDefaultAsync(m => m.ID == id);
            _context.ThirdParties.Remove(thirdParty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ThirdPartyExists(Guid id)
        {
            return _context.ThirdParties.Any(e => e.ID == id);
        }
    }
}
