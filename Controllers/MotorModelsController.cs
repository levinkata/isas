using Isas.Data;
using Isas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class MotorModelsController : Controller
    {
        private readonly InsurerDbContext _context;

        public MotorModelsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: MotorModels
        public async Task<IActionResult> Index(Guid motormakeid, int? page)
        {
            ViewData["MotorMakeID"] = motormakeid;

            var motormodels = from c in _context.MotorModels
                                .Include(m => m.MotorMake)
                                .Where(r => r.MotorMakeID == motormakeid)
                              orderby c.Name
                             select c;
            int pageSize = 10;
            return View(await PaginatedList<MotorModel>.CreateAsync(motormodels.AsNoTracking(), page ?? 1,
                pageSize));
        }

        // GET: MotorModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorModel = await _context.MotorModels.SingleOrDefaultAsync(m => m.ID == id);
            if (motorModel == null)
            {
                return NotFound();
            }

            return View(motorModel);
        }

        // GET: MotorModels/Create
        public IActionResult Create(Guid motormakeid)
        {
            ViewData["MotorMakeID"] = motormakeid;
            return View();
        }

        // POST: MotorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MotorMakeID,Name")] MotorModel motorModel)
        {
            if (ModelState.IsValid)
            {
                motorModel.ID = Guid.NewGuid();
                _context.Add(motorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { motormakeid = motorModel.MotorMakeID });
            }
            ViewData["MotorMakeID"] = motorModel.MotorMakeID;
            return View(motorModel);
        }

        // GET: MotorModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorModel = await _context.MotorModels.SingleOrDefaultAsync(m => m.ID == id);
            if (motorModel == null)
            {
                return NotFound();
            }
            ViewData["MotorMakeID"] = new SelectList(_context.MotorMakes, "ID", "Name", motorModel.MotorMakeID);
            return View(motorModel);
        }

        // POST: MotorModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,MotorMakeID,Name")] MotorModel motorModel)
        {
            if (id != motorModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorModelExists(motorModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { motormakeid = motorModel.MotorMakeID });
            }
            ViewData["MotorMakeID"] = motorModel.MotorMakeID;
            return View(motorModel);
        }

        // GET: MotorModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorModel = await _context.MotorModels.SingleOrDefaultAsync(m => m.ID == id);
            if (motorModel == null)
            {
                return NotFound();
            }

            return View(motorModel);
        }

        // POST: MotorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorModel = await _context.MotorModels.SingleOrDefaultAsync(m => m.ID == id);
            _context.MotorModels.Remove(motorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { motormakeid = motorModel.MotorMakeID });
        }

        private bool MotorModelExists(Guid id)
        {
            return _context.MotorModels.Any(e => e.ID == id);
        }
    }
}
