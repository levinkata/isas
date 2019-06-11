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
    public class RoofTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public RoofTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: RoofTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoofTypes.OrderBy(r => r.Name).ToListAsync());
        }

        // GET: RoofTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roofType = await _context.RoofTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (roofType == null)
            {
                return NotFound();
            }

            return View(roofType);
        }

        // GET: RoofTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoofTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] RoofType roofType)
        {
            if (ModelState.IsValid)
            {
                roofType.ID = Guid.NewGuid();
                _context.Add(roofType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roofType);
        }

        // GET: RoofTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roofType = await _context.RoofTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (roofType == null)
            {
                return NotFound();
            }
            return View(roofType);
        }

        // POST: RoofTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] RoofType roofType)
        {
            if (id != roofType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roofType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoofTypeExists(roofType.ID))
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
            return View(roofType);
        }

        // GET: RoofTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roofType = await _context.RoofTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (roofType == null)
            {
                return NotFound();
            }

            return View(roofType);
        }

        // POST: RoofTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roofType = await _context.RoofTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.RoofTypes.Remove(roofType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoofTypeExists(Guid id)
        {
            return _context.RoofTypes.Any(e => e.ID == id);
        }
    }
}
