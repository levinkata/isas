using Isas.Data;
using Isas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class RegionsController : Controller
    {
        private readonly InsurerDbContext _context;

        public RegionsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.OrderBy(r => r.Name).ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.SingleOrDefaultAsync(m => m.ID == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Name")] Region region)
        {
            if (ModelState.IsValid)
            {
                region.ID = Guid.NewGuid();
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.SingleOrDefaultAsync(m => m.ID == id);
            if (region == null)
            {
                return NotFound();
            }
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Description,Name")] Region region)
        {
            if (id != region.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.ID))
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
            return View(region);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.SingleOrDefaultAsync(m => m.ID == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var region = await _context.Regions.SingleOrDefaultAsync(m => m.ID == id);
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegionExists(Guid id)
        {
            return _context.Regions.Any(e => e.ID == id);
        }
    }
}
