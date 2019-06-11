using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    //[Authorize(Policy = "AdministratorOnly")]
    //[Authorize(Policy = "EmployeeId")]
    [Authorize]
    public class ContainersController : Controller
    {
        private readonly InsurerDbContext _context;

        public ContainersController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Containers
        public async Task<IActionResult> Index()
        {            
            var containers = from c in _context.Containers
                             .Include(c => c.Country)
                             .Include(c => c.Products)
                             .OrderBy(n => n.Name)
                             select c;

            return View(await containers.AsNoTracking().ToListAsync());
        }

        // GET: Containers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                            .Include(c => c.Country)
                            .Include(c => c.Products)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(m => m.ID == id);
            return View(container);
        }

        // GET: Containers/Create
        public async  Task<IActionResult> Create()
        {
            ContainerViewModel viewModel = new ContainerViewModel
            {
                CountryList = new SelectList(await _context.Countries.OrderBy(c => c.Name).ToListAsync(),
                                                "ID", "Name", await _context.Countries.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Containers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContainerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Container container = new Container();
                    container = viewModel.Container;
                    container.ID = Guid.NewGuid();
                    container.AddedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    container.DateAdded = DateTime.Now;
                    _context.Add(container);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(viewModel);
        }

        // GET: Containers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                                .Include(c => c.Country)
                                .AsNoTracking()
                                .SingleOrDefaultAsync(m => m.ID == id);

            if (container == null)
            {
                return NotFound();
            }

            ContainerViewModel viewModel = new ContainerViewModel
            {
                Container = container,
                CountryList = new SelectList(await _context.Countries.OrderBy(c => c.Name).ToListAsync(),
                                                "ID", "Name", container.CountryID)
            };
            return View(viewModel);
        }

        // POST: Containers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContainerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Container container = new Container();
                    container = viewModel.Container;
                    container.ModifiedBy = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    container.DateModified = DateTime.Now;
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            viewModel.CountryList = new SelectList(await _context.Countries.OrderBy(c => c.Name).ToListAsync(),
                                        "ID", "Name", viewModel.Container.CountryID);
            return View(viewModel);
        }

        // GET: Containers/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                                .Include(c => c.Country)
                                .AsNoTracking()
                                .AsNoTracking()
                                .SingleOrDefaultAsync(m => m.ID == id);

            if (container == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(container);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var container = await _context.Containers
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (container == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Containers.Remove(container);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
        }

        private bool ContainerExists(Guid id)
        {
            return _context.Containers.Any(e => e.ID == id);
        }
    }
}
