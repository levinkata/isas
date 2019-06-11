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
    public class TitlesController : Controller
    {
        private readonly InsurerDbContext _context;

        public TitlesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titles.OrderBy(t => t.Name).ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Title title)
        {
            if (ModelState.IsValid)
            {
                title.ID = Guid.NewGuid();
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] Title title)
        {
            if (id != title.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.ID))
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
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var title = await _context.Titles.SingleOrDefaultAsync(m => m.ID == id);
            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TitleExists(Guid id)
        {
            return _context.Titles.Any(e => e.ID == id);
        }
    }
}
