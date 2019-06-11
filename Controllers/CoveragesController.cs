using Isas.Data;
using Isas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.JavaScript;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class CoveragesController : Controller
    {
        private readonly InsurerDbContext _context;

        public CoveragesController(InsurerDbContext context)
        {
            _context = context;    
        }

        public IActionResult Grid()
        {
            ViewBag.data = _context.Coverages.OrderBy(c => c.Name).ToList();
            return View();
        }
        
        public ActionResult CellEditInsert([FromBody]CRUDModel<Coverage> coverage)
        {
            coverage.Value.ID = Guid.NewGuid();
            _context.Add(coverage.Value);
            _context.SaveChanges();
            return Json(coverage);
        }

        // GET: CoverTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coverages.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: CoverTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverType = await _context.Coverages.SingleOrDefaultAsync(m => m.ID == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // GET: CoverTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoverTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Coverage coverage)
        {
            if (ModelState.IsValid)
            {
                coverage.ID = Guid.NewGuid();
                _context.Add(coverage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coverage);
        }

        // GET: CoverTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverType = await _context.Coverages.SingleOrDefaultAsync(m => m.ID == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        // POST: CoverTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] Coverage coverage)
        {
            if (id != coverage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coverage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoverTypeExists(coverage.ID))
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
            return View(coverage);
        }

        // GET: CoverTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverType = await _context.Coverages.SingleOrDefaultAsync(m => m.ID == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // POST: CoverTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coverage = await _context.Coverages.SingleOrDefaultAsync(m => m.ID == id);
            _context.Coverages.Remove(coverage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoverTypeExists(Guid id)
        {
            return _context.Coverages.Any(e => e.ID == id);
        }
    }
}
