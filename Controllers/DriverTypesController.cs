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
    public class DriverTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public DriverTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: DriverTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DriverTypes.OrderBy(d => d.Name).ToListAsync());
        }

        // GET: DriverTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverType = await _context.DriverTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (driverType == null)
            {
                return NotFound();
            }

            return View(driverType);
        }

        // GET: DriverTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriverTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] DriverType driverType)
        {
            if (ModelState.IsValid)
            {
                driverType.ID = Guid.NewGuid();
                _context.Add(driverType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(driverType);
        }

        // GET: DriverTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverType = await _context.DriverTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (driverType == null)
            {
                return NotFound();
            }
            return View(driverType);
        }

        // POST: DriverTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] DriverType driverType)
        {
            if (id != driverType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverTypeExists(driverType.ID))
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
            return View(driverType);
        }

        // GET: DriverTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverType = await _context.DriverTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (driverType == null)
            {
                return NotFound();
            }

            return View(driverType);
        }

        // POST: DriverTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var driverType = await _context.DriverTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.DriverTypes.Remove(driverType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DriverTypeExists(Guid id)
        {
            return _context.DriverTypes.Any(e => e.ID == id);
        }
    }
}
