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
    public class BulkHandleGeneratorsController : Controller
    {
        private readonly InsurerDbContext _context;

        public BulkHandleGeneratorsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: BulkHandleGenerators
        public async Task<IActionResult> Index(string tableName)
        {
            return View(await _context.BulkHandleGenerators
                        .Where(t => t.TableName == tableName)
                        .ToListAsync());
        }

        // GET: BulkHandleGenerators/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var bulkHandleGenerator = await _context.BulkHandleGenerators.SingleOrDefaultAsync(m => m.BulkNumber == Id);
            if (bulkHandleGenerator == null)
            {
                return NotFound();
            }

            return View(bulkHandleGenerator);
        }

        // GET: BulkHandleGenerators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BulkHandleGenerators/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BulkNumber,AddedBy,BulkDate,DateAdded,RecordCount,TableName")] BulkHandleGenerator bulkHandleGenerator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bulkHandleGenerator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bulkHandleGenerator);
        }

        // GET: BulkHandleGenerators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulkHandleGenerator = await _context.BulkHandleGenerators.SingleOrDefaultAsync(m => m.BulkNumber == id);
            if (bulkHandleGenerator == null)
            {
                return NotFound();
            }
            return View(bulkHandleGenerator);
        }

        // POST: BulkHandleGenerators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BulkNumber,AddedBy,BulkDate,DateAdded,RecordCount,TableName")] BulkHandleGenerator bulkHandleGenerator)
        {
            if (id != bulkHandleGenerator.BulkNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bulkHandleGenerator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BulkHandleGeneratorExists(bulkHandleGenerator.BulkNumber))
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
            return View(bulkHandleGenerator);
        }

        // GET: BulkHandleGenerators/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var bulkHandleGenerator = await _context.BulkHandleGenerators.SingleOrDefaultAsync(m => m.BulkNumber == Id);
            if (bulkHandleGenerator == null)
            {
                return NotFound();
            }

            return View(bulkHandleGenerator);
        }

        // POST: BulkHandleGenerators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var bulkHandleGenerator = await _context.BulkHandleGenerators.SingleOrDefaultAsync(m => m.BulkNumber == Id);
            _context.BulkHandleGenerators.Remove(bulkHandleGenerator);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BulkHandleGeneratorExists(int Id)
        {
            return _context.BulkHandleGenerators.Any(e => e.BulkNumber == Id);
        }
    }
}
