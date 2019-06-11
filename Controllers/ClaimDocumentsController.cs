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
    public class ClaimDocumentsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClaimDocumentsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ClaimDocuments
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimDocuments.OrderBy(c => c.Name).AsNoTracking().ToListAsync());
        }

        // GET: ClaimDocuments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDocument = await _context.ClaimDocuments.SingleOrDefaultAsync(m => m.ID == id);
            if (claimDocument == null)
            {
                return NotFound();
            }

            return View(claimDocument);
        }


        // GET: ClaimDocuments/Create
        public IActionResult Create()
        {
            ClaimDocument claimDocument = new ClaimDocument();

            ClaimDocumentViewModel viewModel = new ClaimDocumentViewModel
            {
                ClaimDocument = claimDocument
            };
            return View(viewModel);
        }

        // POST: ClaimDocuments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimDocumentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimDocument claimDocument = new ClaimDocument();
                claimDocument = viewModel.ClaimDocument;
                claimDocument.ID = Guid.NewGuid();
                _context.Add(claimDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: ClaimDocuments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDocument = await _context.ClaimDocuments.SingleOrDefaultAsync(m => m.ID == id);
            if (claimDocument == null)
            {
                return NotFound();
            }
            ClaimDocumentViewModel viewModel = new ClaimDocumentViewModel
            {
                ClaimDocument = claimDocument
            };
            return View(viewModel);
        }

        // POST: ClaimDocuments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClaimDocumentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimDocument claimDocument = new ClaimDocument();
                claimDocument = viewModel.ClaimDocument;
                try
                {
                    _context.Update(claimDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimDocumentExists(claimDocument.ID))
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
            return View(viewModel);
        }

        // GET: ClaimDocuments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDocument = await _context.ClaimDocuments.SingleOrDefaultAsync(m => m.ID == id);
            if (claimDocument == null)
            {
                return NotFound();
            }

            return View(claimDocument);
        }

        // POST: ClaimDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var claimDocument = await _context.ClaimDocuments.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClaimDocuments.Remove(claimDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClaimDocumentExists(Guid id)
        {
            return _context.ClaimDocuments.Any(e => e.ID == id);
        }
    }
}
