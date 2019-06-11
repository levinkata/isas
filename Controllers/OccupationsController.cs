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
    public class OccupationsController : Controller
    {
        private readonly InsurerDbContext _context;

        public OccupationsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Occupations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Occupations.OrderBy(o => o.Name).ToListAsync());
        }

        // GET: Occupations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.SingleOrDefaultAsync(m => m.ID == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // GET: Occupations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                occupation.ID = Guid.NewGuid();
                _context.Add(occupation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        // GET: Occupations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.SingleOrDefaultAsync(m => m.ID == id);
            if (occupation == null)
            {
                return NotFound();
            }
            return View(occupation);
        }

        // POST: Occupations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] Occupation occupation)
        {
            if (id != occupation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occupation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccupationExists(occupation.ID))
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
            return View(occupation);
        }

        // GET: Occupations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.SingleOrDefaultAsync(m => m.ID == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var occupation = await _context.Occupations.SingleOrDefaultAsync(m => m.ID == id);
            _context.Occupations.Remove(occupation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OccupationExists(Guid id)
        {
            return _context.Occupations.Any(e => e.ID == id);
        }
    }
}
