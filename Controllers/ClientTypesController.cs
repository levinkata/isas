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
    public class ClientTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClientTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: ClientClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientTypes.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: ClientClasses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // GET: ClientClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ClientType clientType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clientType);
        }

        // GET: ClientClasses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (clientClass == null)
            {
                return NotFound();
            }
            return View(clientClass);
        }

        // POST: ClientClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] ClientType clientType)
        {
            if (id != clientType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientTypeExists(clientType.ID))
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
            return View(clientType);
        }

        // GET: ClientClasses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // POST: ClientClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clientType = await _context.ClientTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClientTypes.Remove(clientType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientTypeExists(Guid id)
        {
            return _context.ClientTypes.Any(e => e.ID == id);
        }
    }
}
