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
    public class AffectedsController : Controller
    {
        private readonly InsurerDbContext _context;

        public AffectedsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Affecteds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Affecteds.OrderBy(a => a.Name).ToListAsync());
        }

        // GET: Affecteds/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affected = await _context.Affecteds.SingleOrDefaultAsync(m => m.ID == id);
            if (affected == null)
            {
                return NotFound();
            }

            return View(affected);
        }

        // GET: Affecteds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Affecteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Affected affected)
        {
            if (ModelState.IsValid)
            {
                affected.ID = Guid.NewGuid();
                _context.Add(affected);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(affected);
        }

        // GET: Affecteds/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affected = await _context.Affecteds.SingleOrDefaultAsync(m => m.ID == id);
            if (affected == null)
            {
                return NotFound();
            }
            return View(affected);
        }

        // POST: Affecteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] Affected affected)
        {
            if (id != affected.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(affected);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffectedExists(affected.ID))
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
            return View(affected);
        }

        // GET: Affecteds/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affected = await _context.Affecteds.SingleOrDefaultAsync(m => m.ID == id);
            if (affected == null)
            {
                return NotFound();
            }

            return View(affected);
        }

        // POST: Affecteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var affected = await _context.Affecteds.SingleOrDefaultAsync(m => m.ID == id);
            _context.Affecteds.Remove(affected);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AffectedExists(Guid id)
        {
            return _context.Affecteds.Any(e => e.ID == id);
        }
    }
}
