using Isas.Data;
using Isas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class PayeeClassesController : Controller
    {
        private readonly InsurerDbContext _context;

        public PayeeClassesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: PayeeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PayeeClasses.OrderBy(p => p.Name).ToListAsync());
        }

        // GET: PayeeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payeeClass = await _context.PayeeClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (payeeClass == null)
            {
                return NotFound();
            }

            return View(payeeClass);
        }

        // GET: PayeeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayeeClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PayeeClass payeeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payeeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payeeClass);
        }

        // GET: PayeeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payeeClass = await _context.PayeeClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (payeeClass == null)
            {
                return NotFound();
            }
            return View(payeeClass);
        }

        // POST: PayeeClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PayeeClass payeeClass)
        {
            if (id != payeeClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payeeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayeeClassExists(payeeClass.ID))
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
            return View(payeeClass);
        }

        // GET: PayeeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payeeClass = await _context.PayeeClasses.SingleOrDefaultAsync(m => m.ID == id);
            if (payeeClass == null)
            {
                return NotFound();
            }

            return View(payeeClass);
        }

        // POST: PayeeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payeeClass = await _context.PayeeClasses.SingleOrDefaultAsync(m => m.ID == id);
            _context.PayeeClasses.Remove(payeeClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PayeeClassExists(int id)
        {
            return _context.PayeeClasses.Any(e => e.ID == id);
        }
    }
}
