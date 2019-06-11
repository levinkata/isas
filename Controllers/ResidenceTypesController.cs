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
    public class ResidenceTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public ResidenceTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ResidenceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResidenceTypes.OrderBy(r => r.Name).ToListAsync());
        }

        // GET: ResidenceTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (residenceType == null)
            {
                return NotFound();
            }

            return View(residenceType);
        }

        // GET: ResidenceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResidenceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ResidenceType residenceType)
        {
            if (ModelState.IsValid)
            {
                residenceType.ID = Guid.NewGuid();
                _context.Add(residenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(residenceType);
        }

        // GET: ResidenceTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (residenceType == null)
            {
                return NotFound();
            }
            return View(residenceType);
        }

        // POST: ResidenceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] ResidenceType residenceType)
        {
            if (id != residenceType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residenceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidenceTypeExists(residenceType.ID))
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
            return View(residenceType);
        }

        // GET: ResidenceTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (residenceType == null)
            {
                return NotFound();
            }

            return View(residenceType);
        }

        // POST: ResidenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var residenceType = await _context.ResidenceTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.ResidenceTypes.Remove(residenceType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResidenceTypeExists(Guid id)
        {
            return _context.ResidenceTypes.Any(e => e.ID == id);
        }
    }
}
