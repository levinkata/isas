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
    public class AllRisksController : Controller
    {
        private readonly InsurerDbContext _context;

        public AllRisksController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: AllRisks
        public async Task<IActionResult> Index(Guid policyId)
        {
            var allrisks = _context.AllRisks
                .Include(a => a.Component)
                .Include(a => a.Policy)
                .Where(a => a.PolicyID == policyId);

            return View(await allrisks.OrderBy(c => c.Component.Name).ToListAsync());
        }

        // GET: AllRisks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRisk = await _context.AllRisks.SingleOrDefaultAsync(m => m.ID == id);
            if (allRisk == null)
            {
                return NotFound();
            }

            return View(allRisk);
        }

        // GET: AllRisks/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            AllRisk allrisk = new AllRisk
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            AllRiskViewModel viewModel = new AllRiskViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                AllRisk = allrisk,
                ComponentList = new SelectList(await _context.Components
                                    .AsNoTracking()
                                    .OrderBy(n => n.Name)
                                    .ToListAsync(), "ID", "Name"),
            };
            return View(viewModel);
        }

        // POST: AllRisks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllRiskViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //  Check that Start Date and End Date are 
                    //  within Policy Cover Start and Cover End Date
                    Guid policyId = viewModel.PolicyID;
                    viewModel.ErrMsg = string.Empty;

                    var startDate = viewModel.AllRisk.StartDate;
                    var endDate = viewModel.AllRisk.EndDate;

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
                        AllRisk allrisk = viewModel.AllRisk;
                        allrisk.ID = Guid.NewGuid();
                        allrisk.PolicyID = policyId;
                        _context.Add(allrisk);
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
                                            .ToListAsync(), "ID", "Name", viewModel.AllRisk.ComponentID);
            return View(viewModel);
        }

        // GET: AllRisks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRisk = await _context.AllRisks.SingleOrDefaultAsync(m => m.ID == id);
            if (allRisk == null)
            {
                return NotFound();
            }
            SelectList ComponentList = new SelectList(_context.Components, "ID", "Name", allRisk.ComponentID);
            AllRiskViewModel viewModel = new AllRiskViewModel
            {
                AllRisk = allRisk,
                ComponentList = ComponentList,
            };
            return View(viewModel);
        }

        // POST: AllRisks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AllRiskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AllRisk allRisk = viewModel.AllRisk;
                try
                {
                    _context.Update(allRisk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllRiskExists(allRisk.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { policyid = allRisk.PolicyID });
            }
            return View(viewModel);
        }

        // GET: AllRisks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRisk = await _context.AllRisks.SingleOrDefaultAsync(m => m.ID == id);
            if (allRisk == null)
            {
                return NotFound();
            }

            return View(allRisk);
        }

        // POST: AllRisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var allRisk = await _context.AllRisks.SingleOrDefaultAsync(m => m.ID == id);
            _context.AllRisks.Remove(allRisk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AllRiskExists(Guid id)
        {
            return _context.AllRisks.Any(e => e.ID == id);
        }
    }
}
