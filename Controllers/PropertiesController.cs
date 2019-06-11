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
    public class PropertiesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PropertiesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Properties
        public async Task<IActionResult> Index(Guid policyId)
        {
            var properties = _context.Properties
                .Include(c => c.Coverage)
                .Include(p => p.Policy)
                .Include(r => r.ResidenceType)
                .Include(r => r.RoofType)
                .Include(w => w.WallType)
                .Where(p => p.PolicyID == policyId);

            return View(await properties.OrderBy(l => l.Location).ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            Property property = new Property
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            PropertyViewModel viewModel = new PropertyViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Property = property,
                CoverageList = new SelectList(await _context.Coverages
                                    .AsNoTracking()
                                    .ToListAsync(), "ID", "Name"),
                ResidenceTypeList = new SelectList(await _context.ResidenceTypes
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name"),
                RoofTypeList = new SelectList(await _context.RoofTypes
                                    .AsNoTracking()
                                    .ToListAsync(), "ID", "Name"),
                WallTypeList = new SelectList(await _context.WallTypes
                                    .AsNoTracking()
                                    .ToListAsync(), "ID", "Name")
            };
            return View(viewModel);
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //  Check that Start Date and End Date are within Policy Cover Start and Cover End Date
                    Guid policyId = viewModel.PolicyID;
                    viewModel.ErrMsg = string.Empty;

                    var startDate = viewModel.Property.StartDate;
                    var endDate = viewModel.Property.EndDate;

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
                        Property property = viewModel.Property;
                        property.ID = Guid.NewGuid();
                        property.PolicyID = policyId;
                        _context.Add(property);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("PolicyRisks", "Policies",
                            new { productId = viewModel.ProductID, clientId = viewModel.ClientID, policyid = viewModel.PolicyID });
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;
                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.CoverageList = new SelectList(await _context.Coverages
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Property.CoverageID);
            viewModel.ResidenceTypeList = new SelectList(await _context.ResidenceTypes
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Property.ResidenceTypeID);
            viewModel.RoofTypeList = new SelectList(await _context.RoofTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Property.RoofTypeID);
            viewModel.WallTypeList = new SelectList(await _context.WallTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Property.WallTypeID);
            return View(viewModel);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["CoverageID"] = new SelectList(_context.Coverages, "ID", "Name", @property.CoverageID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", @property.PolicyID);
            ViewData["ResidenceTypeID"] = new SelectList(_context.ResidenceTypes, "ID", "Name", @property.ResidenceTypeID);
            ViewData["RoofTypeID"] = new SelectList(_context.RoofTypes, "ID", "Name", @property.RoofTypeID);
            ViewData["WallTypeID"] = new SelectList(_context.WallTypes, "ID", "Name", @property.WallTypeID);
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,BondHolder,CoverageID,EndDate,Location,PolicyID,Premium,ResidenceTypeID,RoofTypeID,StartDate,Value,WallTypeID")] Property @property)
        {
            if (id != @property.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.ID))
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
            ViewData["CoverageID"] = new SelectList(_context.Coverages, "ID", "Name", @property.CoverageID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", @property.PolicyID);
            ViewData["ResidenceTypeID"] = new SelectList(_context.ResidenceTypes, "ID", "Name", @property.ResidenceTypeID);
            ViewData["RoofTypeID"] = new SelectList(_context.RoofTypes, "ID", "Name", @property.RoofTypeID);
            ViewData["WallTypeID"] = new SelectList(_context.WallTypes, "ID", "Name", @property.WallTypeID);
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.ID == id);
            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.ID == id);
        }
    }
}
