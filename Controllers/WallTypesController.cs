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
    public class WallTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public WallTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: WallTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WallTypes.OrderBy(w => w.Name).ToListAsync());
        }

        // GET: WallTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallType = await _context.WallTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (wallType == null)
            {
                return NotFound();
            }

            return View(wallType);
        }

        // GET: WallTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WallTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] WallType wallType)
        {
            if (ModelState.IsValid)
            {
                wallType.ID = Guid.NewGuid();
                _context.Add(wallType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wallType);
        }

        // GET: WallTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallType = await _context.WallTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (wallType == null)
            {
                return NotFound();
            }
            return View(wallType);
        }

        // POST: WallTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] WallType wallType)
        {
            if (id != wallType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WallTypeExists(wallType.ID))
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
            return View(wallType);
        }

        // GET: WallTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallType = await _context.WallTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (wallType == null)
            {
                return NotFound();
            }

            return View(wallType);
        }

        // POST: WallTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var wallType = await _context.WallTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.WallTypes.Remove(wallType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WallTypeExists(Guid id)
        {
            return _context.WallTypes.Any(e => e.ID == id);
        }
    }
}
