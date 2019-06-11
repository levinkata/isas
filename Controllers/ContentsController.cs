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
    public class ContentsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ContentsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Contents
        public async Task<IActionResult> Index(Guid policyId)
        {
            var contents = _context.Contents
                .Include(c => c.Policy)
                .Include(c => c.ResidenceType)
                .Include(c => c.RoofType)
                .Include(c => c.WallType)
                .Where(p => p.PolicyID == policyId);

            return View(await contents.OrderBy(c => c.Location).ToListAsync());
        }

        // GET: Contents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents.SingleOrDefaultAsync(m => m.ID == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // GET: Contents/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            Content content = new Content
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            ContentViewModel viewModel = new ContentViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Content = content,
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

        // POST: Contents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //  Check that Start Date and End Date are within Policy Cover Start and Cover End Date
                    Guid policyId = viewModel.PolicyID;
                    viewModel.ErrMsg = string.Empty;

                    var startDate = viewModel.Content.StartDate;
                    var endDate = viewModel.Content.EndDate;

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
                        Content content = viewModel.Content;
                        content.ID = Guid.NewGuid();
                        content.PolicyID = policyId;
                        _context.Add(content);
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
            viewModel.ResidenceTypeList = new SelectList(await _context.ResidenceTypes
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Content.ResidenceTypeID);
            viewModel.RoofTypeList = new SelectList(await _context.RoofTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Content.RoofTypeID);
            viewModel.WallTypeList = new SelectList(await _context.WallTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Content.WallTypeID);
            return View(viewModel);
        }

        // GET: Contents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents.SingleOrDefaultAsync(m => m.ID == id);
            if (content == null)
            {
                return NotFound();
            }
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", content.PolicyID);
            ViewData["ResidenceTypeID"] = new SelectList(_context.ResidenceTypes, "ID", "Name", content.ResidenceTypeID);
            ViewData["RoofTypeID"] = new SelectList(_context.RoofTypes, "ID", "Name", content.RoofTypeID);
            ViewData["WallTypeID"] = new SelectList(_context.WallTypes, "ID", "Name", content.WallTypeID);
            return View(content);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,EndDate,Location,PolicyID,Premium,ResidenceTypeID,RoofTypeID,StartDate,Value,WallTypeID")] Content content)
        {
            if (id != content.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.ID))
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
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", content.PolicyID);
            ViewData["ResidenceTypeID"] = new SelectList(_context.ResidenceTypes, "ID", "Name", content.ResidenceTypeID);
            ViewData["RoofTypeID"] = new SelectList(_context.RoofTypes, "ID", "Name", content.RoofTypeID);
            ViewData["WallTypeID"] = new SelectList(_context.WallTypes, "ID", "Name", content.WallTypeID);
            return View(content);
        }

        // GET: Contents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents.SingleOrDefaultAsync(m => m.ID == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var content = await _context.Contents.SingleOrDefaultAsync(m => m.ID == id);
            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContentExists(Guid id)
        {
            return _context.Contents.Any(e => e.ID == id);
        }
    }
}
