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
    public class ClaimClassesController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClaimClassesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ClaimClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimClasses.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: ClaimClasses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimClass = await _context.ClaimClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimClass == null)
            {
                return NotFound();
            }

            return View(claimClass);
        }

        // GET: ClaimClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaimClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AffectCFG,Name")] ClaimClass claimClass)
        {
            if (ModelState.IsValid)
            {
                claimClass.ID = Guid.NewGuid();
                _context.Add(claimClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(claimClass);
        }

        // GET: ClaimClasses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimClass = await _context.ClaimClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimClass == null)
            {
                return NotFound();
            }
            return View(claimClass);
        }

        // POST: ClaimClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,AffectCFG,Name")] ClaimClass claimClass)
        {
            if (id != claimClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimClassExists(claimClass.ID))
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
            return View(claimClass);
        }

        // GET: ClaimClasses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimClass = await _context.ClaimClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimClass == null)
            {
                return NotFound();
            }

            return View(claimClass);
        }

        // POST: ClaimClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var claimClass = await _context.ClaimClasses.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClaimClasses.Remove(claimClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClaimClassExists(Guid id)
        {
            return _context.ClaimClasses.Any(e => e.ID == id);
        }
    }
}
