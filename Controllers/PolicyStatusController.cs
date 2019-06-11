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
    public class PolicyStatusController : Controller
    {
        private readonly InsurerDbContext _context;

        public PolicyStatusController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: PolicyStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PolicyStatuses.OrderBy(p => p.Name).ToListAsync());
        }

        // GET: PolicyStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyStatus = await _context.PolicyStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (policyStatus == null)
            {
                return NotFound();
            }

            return View(policyStatus);
        }

        // GET: PolicyStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicyStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IsUpdatable,Name")] PolicyStatus policyStatus)
        {
            if (ModelState.IsValid)
            {
                policyStatus.ID = Guid.NewGuid();
                _context.Add(policyStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(policyStatus);
        }

        // GET: PolicyStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyStatus = await _context.PolicyStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (policyStatus == null)
            {
                return NotFound();
            }
            return View(policyStatus);
        }

        // POST: PolicyStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,IsUpdatable,Name")] PolicyStatus policyStatus)
        {
            if (id != policyStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyStatusExists(policyStatus.ID))
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
            return View(policyStatus);
        }

        // GET: PolicyStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyStatus = await _context.PolicyStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (policyStatus == null)
            {
                return NotFound();
            }

            return View(policyStatus);
        }

        // POST: PolicyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var policyStatus = await _context.PolicyStatuses.SingleOrDefaultAsync(m => m.ID == id);
            _context.PolicyStatuses.Remove(policyStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PolicyStatusExists(Guid id)
        {
            return _context.PolicyStatuses.Any(e => e.ID == id);
        }
    }
}
