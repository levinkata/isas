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
    public class PolicyFrequenciesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PolicyFrequenciesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: PolicyFrequencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.PolicyFrequencies.OrderBy(f => f.Name).ToListAsync());
        }

        // GET: PolicyFrequencies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyFrequency = await _context.PolicyFrequencies.SingleOrDefaultAsync(m => m.ID == id);
            if (policyFrequency == null)
            {
                return NotFound();
            }

            return View(policyFrequency);
        }

        // GET: PolicyFrequencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicyFrequencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Divisor,Name")] PolicyFrequency policyFrequency)
        {
            if (ModelState.IsValid)
            {
                policyFrequency.ID = Guid.NewGuid();
                _context.Add(policyFrequency);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(policyFrequency);
        }

        // GET: PolicyFrequencies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyFrequency = await _context.PolicyFrequencies.SingleOrDefaultAsync(m => m.ID == id);
            if (policyFrequency == null)
            {
                return NotFound();
            }
            return View(policyFrequency);
        }

        // POST: PolicyFrequencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Divisor,Name")] PolicyFrequency policyFrequency)
        {
            if (id != policyFrequency.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyFrequency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyFrequencyExists(policyFrequency.ID))
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
            return View(policyFrequency);
        }

        // GET: PolicyFrequencies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyFrequency = await _context.PolicyFrequencies.SingleOrDefaultAsync(m => m.ID == id);
            if (policyFrequency == null)
            {
                return NotFound();
            }

            return View(policyFrequency);
        }

        // POST: PolicyFrequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var policyFrequency = await _context.PolicyFrequencies.SingleOrDefaultAsync(m => m.ID == id);
            _context.PolicyFrequencies.Remove(policyFrequency);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PolicyFrequencyExists(Guid id)
        {
            return _context.PolicyFrequencies.Any(e => e.ID == id);
        }
    }
}
