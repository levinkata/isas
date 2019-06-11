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
    public class MotorMakesController : Controller
    {
        private readonly InsurerDbContext _context;

        public MotorMakesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: MotorMakes
        public async Task<IActionResult> Index(int? page)
        {
            var motormakes = from c in _context.MotorMakes
                             orderby c.Name
                             select c;
            int pageSize = 10;
            return View(await PaginatedList<MotorMake>.CreateAsync(motormakes.AsNoTracking(), page ?? 1,
                pageSize));
        }

        // GET: MotorMakes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorMake = await _context.MotorMakes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorMake == null)
            {
                return NotFound();
            }

            return View(motorMake);
        }

        // GET: MotorMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] MotorMake motorMake)
        {
            if (ModelState.IsValid)
            {
                motorMake.ID = Guid.NewGuid();
                _context.Add(motorMake);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(motorMake);
        }

        // GET: MotorMakes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorMake = await _context.MotorMakes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorMake == null)
            {
                return NotFound();
            }
            return View(motorMake);
        }

        // POST: MotorMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] MotorMake motorMake)
        {
            if (id != motorMake.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorMake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorMakeExists(motorMake.ID))
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
            return View(motorMake);
        }

        // GET: MotorMakes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorMake = await _context.MotorMakes.SingleOrDefaultAsync(m => m.ID == id);
            if (motorMake == null)
            {
                return NotFound();
            }

            return View(motorMake);
        }

        // POST: MotorMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorMake = await _context.MotorMakes.SingleOrDefaultAsync(m => m.ID == id);
            _context.MotorMakes.Remove(motorMake);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MotorMakeExists(Guid id)
        {
            return _context.MotorMakes.Any(e => e.ID == id);
        }
    }
}
