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
    public class CountriesController : Controller
    {
        private readonly InsurerDbContext _context;

        public CountriesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Countries
        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //return View(await _context.Countries.OrderBy(c => c.Name).ToListAsync());
            var countries = from c in _context.Countries
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    countries = countries.OrderByDescending(c => c.Name);
                    break;
                default:
                    countries = countries.OrderBy(c => c.Name);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Country>.CreateAsync(countries.AsNoTracking(), page ?? 1,
                pageSize));
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DialingCode,ISOCode,ISOCurrency,Name,Tax")] Country country)
        {
            if (ModelState.IsValid)
            {
                country.ID = Guid.NewGuid();
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,DialingCode,ISOCode,ISOCurrency,Name,Tax")] Country country)
        {
            if (id != country.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.ID))
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
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CountryExists(Guid id)
        {
            return _context.Countries.Any(e => e.ID == id);
        }
    }
}
