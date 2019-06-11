using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class TracingAgentsController : Controller
    {
        private readonly InsurerDbContext _context;

        public TracingAgentsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: TracingAgents
        public async Task<IActionResult> Index(int payeeClassId)
        {
            TracingAgentsViewModel viewModel = new TracingAgentsViewModel
            {
                PayeeClassID = payeeClassId,
                TracingAgents = await _context.TracingAgents
                                .AsNoTracking()
                                .OrderBy(i => i.Name)
                                .ToListAsync()
            };
            return View(viewModel);
        }

        // GET: TracingAgents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracingAgent = await _context.TracingAgents
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(m => m.ID == id);

            if (tracingAgent == null)
            {
                return NotFound();
            }

            return View(tracingAgent);
        }

        // GET: TracingAgents/Create
        public IActionResult Create(int payeeClassId)
        {
            TracingAgent tracingAgent = new TracingAgent
            {
                PayeeClassID = payeeClassId
            };

            TracingAgentViewModel viewModel = new TracingAgentViewModel
            {
                TracingAgent = tracingAgent
            };
            return View(viewModel);
        }

        // POST: TracingAgents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TracingAgentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TracingAgent tracingAgent = new TracingAgent();
                tracingAgent = viewModel.TracingAgent;
                tracingAgent.ID = Guid.NewGuid();
                _context.Add(tracingAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { payeeclassId = viewModel.TracingAgent.PayeeClassID });
            }
            return View(viewModel);
        }

        // GET: TracingAgents/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            TracingAgentViewModel viewModel = new TracingAgentViewModel
            {
                TracingAgent = await _context.TracingAgents.SingleOrDefaultAsync(m => m.ID == Id)
            };
            return View(viewModel);
        }

        // POST: TracingAgents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TracingAgentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TracingAgent tracingAgent = new TracingAgent();
                    tracingAgent = viewModel.TracingAgent;
                    _context.Update(tracingAgent);
                    await _context.SaveChangesAsync();

                    var payeeParams = new object[] { tracingAgent.ID, tracingAgent.Name };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.TracingAgent.PayeeClassID });
                }
                catch (DbUpdateException ex)
                {
                    var errorMsg = ex.InnerException.Message.ToString();

                    viewModel.ErrMsg = errorMsg;
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }
            }
            return View(viewModel);
        }

        // GET: TracingAgents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracingAgent = await _context.TracingAgents.SingleOrDefaultAsync(m => m.ID == id);
            if (tracingAgent == null)
            {
                return NotFound();
            }

            return View(tracingAgent);
        }

        // POST: TracingAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tracingAgent = await _context.TracingAgents.SingleOrDefaultAsync(m => m.ID == id);
            _context.TracingAgents.Remove(tracingAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TracingAgentExists(Guid id)
        {
            return _context.TracingAgents.Any(e => e.ID == id);
        }
    }
}
