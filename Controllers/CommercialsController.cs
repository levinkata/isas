using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    public class CommercialsController : Controller
    {
        private readonly InsurerDbContext _context;

        public CommercialsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Commercials
        public async Task<IActionResult> Index(Guid policyId)
        {
            var commercials = _context.Commercials
                                    .Include(c => c.Component)
                                    .Include(c => c.Policy)
                                    .AsNoTracking()
                                    .Where(m => m.PolicyID == policyId);

            return View(await commercials.OrderBy(c => c.Component.Name).ToListAsync());
        }

        // GET: Commercials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercial = await _context.Commercials
                .Include(c => c.Component)
                .Include(c => c.Policy)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commercial == null)
            {
                return NotFound();
            }

            return View(commercial);
        }

        // GET: Commercials/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            Commercial commercial = new Commercial
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            CommercialViewModel viewModel = new CommercialViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Commercial = commercial,
                ComponentList = new SelectList(await _context.Components.ToListAsync(),
                                                "ID", "Name", await _context.Components.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Commercials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommercialViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //  Check that Start Date and End Date are within Policy Cover Start and Cover End Date
                    Guid policyId = viewModel.PolicyID;
                    viewModel.ErrMsg = string.Empty;

                    var startDate = viewModel.Commercial.StartDate;
                    var endDate = viewModel.Commercial.EndDate;

                    CompareDates compareDates = new CompareDates(_context);

                    if (compareDates.CompareStartDate(policyId, startDate) < 0)
                    {
                        viewModel.ErrMsg = $"Start Date cannot be earlier than Policy Cover Start Date";
                        ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                    }

                    if (compareDates.CompareEndDate(policyId, endDate) > 0)
                    {
                        viewModel.ErrMsg = $"End Date cannot be later than Policy Cover End Date";
                        ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                    }

                    if (string.IsNullOrEmpty(viewModel.ErrMsg))
                    {
                        Commercial commercial = viewModel.Commercial;
                        commercial.ID = Guid.NewGuid();
                        commercial.PolicyID = policyId;
                        _context.Add(commercial);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("PolicyRisks", "Policies",
                            new { productId = viewModel.ProductID, clientId = viewModel.ClientID, policyId = viewModel.PolicyID });
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;
                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.ComponentList = new SelectList(await _context.Components
                                            .AsNoTracking()
                                            .OrderBy(n => n.Name)
                                            .ToListAsync(), "ID", "Name", viewModel.Commercial.ComponentID);
            return View(viewModel);
        }

        // GET: Commercials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercial = await _context.Commercials.SingleOrDefaultAsync(m => m.ID == id);
            if (commercial == null)
            {
                return NotFound();
            }
            ViewData["ComponentID"] = new SelectList(_context.Components, "ID", "Name", commercial.ComponentID);
            return View(commercial);
        }

        // POST: Commercials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,PolicyID,ComponentID,Description,Motor,Rate,Value,Premium,StartDate,EndDate,DateAdded,AddedBy,DateModified,ModifiedBy")] Commercial commercial)
        {
            if (id != commercial.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommercialExists(commercial.ID))
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
            ViewData["ComponentID"] = new SelectList(_context.Components, "ID", "Name", commercial.ComponentID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "ID", commercial.PolicyID);
            return View(commercial);
        }

        // GET: Commercials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercial = await _context.Commercials
                .Include(c => c.Component)
                .Include(c => c.Policy)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commercial == null)
            {
                return NotFound();
            }

            return View(commercial);
        }

        // POST: Commercials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commercial = await _context.Commercials.SingleOrDefaultAsync(m => m.ID == id);
            _context.Commercials.Remove(commercial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CommercialExists(Guid id)
        {
            return _context.Commercials.Any(e => e.ID == id);
        }
    }
}
