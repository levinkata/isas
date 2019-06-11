using Isas.Data;
using Isas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    public class IncomeClassesController : Controller
    {
        private readonly InsurerDbContext _context;

        public IncomeClassesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: IncomeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomeClasses.AsNoTracking().OrderBy(i => i.Name).ToListAsync());
        }

        // GET: IncomeClasses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeClass = await _context.IncomeClasses
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeClass == null)
            {
                return NotFound();
            }

            return View(incomeClass);
        }

        // GET: IncomeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] IncomeClass incomeClass)
        {
            if (ModelState.IsValid)
            {
                incomeClass.ID = Guid.NewGuid();
                _context.Add(incomeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(incomeClass);
        }

        // GET: IncomeClasses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeClass = await _context.IncomeClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (incomeClass == null)
            {
                return NotFound();
            }
            return View(incomeClass);
        }

        // POST: IncomeClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] IncomeClass incomeClass)
        {
            if (id != incomeClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeClassExists(incomeClass.ID))
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
            return View(incomeClass);
        }

        // GET: IncomeClasses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeClass = await _context.IncomeClasses
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeClass == null)
            {
                return NotFound();
            }

            return View(incomeClass);
        }

        // POST: IncomeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var incomeClass = await _context.IncomeClasses.SingleOrDefaultAsync(m => m.ID == id);
            _context.IncomeClasses.Remove(incomeClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IncomeClassExists(Guid id)
        {
            return _context.IncomeClasses.Any(e => e.ID == id);
        }
    }
}
