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
    public class TransactionTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public TransactionTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: TransactionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransactionTypes.OrderBy(t => t.Name).ToListAsync());
        }

        // GET: TransactionTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (transactionType == null)
            {
                return NotFound();
            }

            return View(transactionType);
        }

        // GET: TransactionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                transactionType.ID = Guid.NewGuid();
                _context.Add(transactionType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transactionType);
        }

        // GET: TransactionTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (transactionType == null)
            {
                return NotFound();
            }
            return View(transactionType);
        }

        // POST: TransactionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] TransactionType transactionType)
        {
            if (id != transactionType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionTypeExists(transactionType.ID))
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
            return View(transactionType);
        }

        // GET: TransactionTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (transactionType == null)
            {
                return NotFound();
            }

            return View(transactionType);
        }

        // POST: TransactionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transactionType = await _context.TransactionTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.TransactionTypes.Remove(transactionType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TransactionTypeExists(Guid id)
        {
            return _context.TransactionTypes.Any(e => e.ID == id);
        }
    }
}
