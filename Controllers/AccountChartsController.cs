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
    public class AccountChartsController : Controller
    {
        private readonly InsurerDbContext _context;

        public AccountChartsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: AccountCharts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountCharts.OrderBy(a => a.AccountCode).ToListAsync());
        }

        // GET: AccountCharts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountChart = await _context.AccountCharts.SingleOrDefaultAsync(m => m.ID == id);
            if (accountChart == null)
            {
                return NotFound();
            }

            return View(accountChart);
        }

        // GET: AccountCharts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountCharts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccountCode,Description,IncomeOrExpense")] AccountChart accountChart)
        {
            if (ModelState.IsValid)
            {
                accountChart.ID = Guid.NewGuid();
                _context.Add(accountChart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountChart);
        }

        // GET: AccountCharts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountChart = await _context.AccountCharts.SingleOrDefaultAsync(m => m.ID == id);
            if (accountChart == null)
            {
                return NotFound();
            }
            return View(accountChart);
        }

        // POST: AccountCharts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,AccountCode,Description,IncomeOrExpense")] AccountChart accountChart)
        {
            if (id != accountChart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountChart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountChartExists(accountChart.ID))
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
            return View(accountChart);
        }

        // GET: AccountCharts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountChart = await _context.AccountCharts.SingleOrDefaultAsync(m => m.ID == id);
            if (accountChart == null)
            {
                return NotFound();
            }

            return View(accountChart);
        }

        // POST: AccountCharts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var accountChart = await _context.AccountCharts.SingleOrDefaultAsync(m => m.ID == id);
            _context.AccountCharts.Remove(accountChart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountChartExists(Guid id)
        {
            return _context.AccountCharts.Any(e => e.ID == id);
        }
    }
}
