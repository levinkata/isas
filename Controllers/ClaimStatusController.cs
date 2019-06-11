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
    public class ClaimStatusController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClaimStatusController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ClaimStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimStatuses.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: ClaimStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimStatus = await _context.ClaimStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimStatus == null)
            {
                return NotFound();
            }

            return View(claimStatus);
        }

        // GET: ClaimStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaimStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IsUpdatable,Name")] ClaimStatus claimStatus)
        {
            if (ModelState.IsValid)
            {
                claimStatus.ID = Guid.NewGuid();
                _context.Add(claimStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(claimStatus);
        }

        // GET: ClaimStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimStatus = await _context.ClaimStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimStatus == null)
            {
                return NotFound();
            }
            return View(claimStatus);
        }

        // POST: ClaimStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,IsUpdatable,Name")] ClaimStatus claimStatus)
        {
            if (id != claimStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimStatusExists(claimStatus.ID))
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
            return View(claimStatus);
        }

        // GET: ClaimStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimStatus = await _context.ClaimStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (claimStatus == null)
            {
                return NotFound();
            }

            return View(claimStatus);
        }

        // POST: ClaimStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var claimStatus = await _context.ClaimStatuses.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClaimStatuses.Remove(claimStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClaimStatusExists(Guid id)
        {
            return _context.ClaimStatuses.Any(e => e.ID == id);
        }
    }
}
