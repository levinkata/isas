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
    public class PremiumTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PremiumTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: PremiumTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PremiumTypes.OrderBy(p => p.Name).ToListAsync());
        }

        // GET: PremiumTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiumType = await _context.PremiumTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (premiumType == null)
            {
                return NotFound();
            }

            return View(premiumType);
        }

        // GET: PremiumTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PremiumTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PremiumType premiumType)
        {
            if (ModelState.IsValid)
            {
                premiumType.ID = Guid.NewGuid();
                _context.Add(premiumType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(premiumType);
        }

        // GET: PremiumTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiumType = await _context.PremiumTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (premiumType == null)
            {
                return NotFound();
            }
            return View(premiumType);
        }

        // POST: PremiumTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] PremiumType premiumType)
        {
            if (id != premiumType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premiumType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremiumTypeExists(premiumType.ID))
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
            return View(premiumType);
        }

        // GET: PremiumTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiumType = await _context.PremiumTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (premiumType == null)
            {
                return NotFound();
            }

            return View(premiumType);
        }

        // POST: PremiumTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var premiumType = await _context.PremiumTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.PremiumTypes.Remove(premiumType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PremiumTypeExists(Guid id)
        {
            return _context.PremiumTypes.Any(e => e.ID == id);
        }
    }
}
