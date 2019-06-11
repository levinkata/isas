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
    public class MotorTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public MotorTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: MotorTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MotorTypes.OrderBy(m => m.Name).ToListAsync());
        }

        // GET: MotorTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorType = await _context.MotorTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorType == null)
            {
                return NotFound();
            }

            return View(motorType);
        }

        // GET: MotorTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] MotorType motorType)
        {
            if (ModelState.IsValid)
            {
                motorType.ID = Guid.NewGuid();
                _context.Add(motorType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(motorType);
        }

        // GET: MotorTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorType = await _context.MotorTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorType == null)
            {
                return NotFound();
            }
            return View(motorType);
        }

        // POST: MotorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] MotorType motorType)
        {
            if (id != motorType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorTypeExists(motorType.ID))
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
            return View(motorType);
        }

        // GET: MotorTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorType = await _context.MotorTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorType == null)
            {
                return NotFound();
            }

            return View(motorType);
        }

        // POST: MotorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorType = await _context.MotorTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.MotorTypes.Remove(motorType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MotorTypeExists(Guid id)
        {
            return _context.MotorTypes.Any(e => e.ID == id);
        }
    }
}
