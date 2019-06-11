using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
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
    public class RisksController : Controller
    {
        private readonly InsurerDbContext _context;

        public RisksController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Risks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Risks.AsNoTracking().OrderBy(p => p.ID).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddRiskClaimDocuments(string riskId, string[] claimdocuments)
        {
            int selectedRiskId = int.Parse(riskId);
            int ro = claimdocuments.Count();
            RiskClaimDocument riskclaimdocument = new RiskClaimDocument();

            for (int i = 0; i < ro; i++)
            {
                riskclaimdocument.RiskID = selectedRiskId;
                riskclaimdocument.ClaimDocumentID = Guid.Parse(claimdocuments[i].ToString());
                _context.Add(riskclaimdocument);
                await _context.SaveChangesAsync();
            }
            
            var updatedclaimdocuments = _context.ClaimDocuments
                                        .Where(i => !i.RiskClaimDocuments
                                        .Any(r => r.RiskID == selectedRiskId))
                                        .ToList();

            var updatedriskclaimdocuments = _context.RiskClaimDocuments
                                            .Include(r => r.ClaimDocument)
                                            .Where(r => r.RiskID == selectedRiskId)
                                            .ToList().Select(r => new SelectListItem
                                            {
                                                Value = r.ClaimDocumentID.ToString(),
                                                Text = r.ClaimDocument.Name
                                            });

            return Json(new { updatedclaimdocuments, updatedriskclaimdocuments });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRiskClaimDocuments(string riskId, string[] claimdocuments)
        {
            int selectedRiskId = int.Parse(riskId);
            int ro = claimdocuments.Count();
            RiskClaimDocument riskclaimdocument = new RiskClaimDocument();
            for (int i = 0; i < ro; i++)
            {
                riskclaimdocument = _context.RiskClaimDocuments
                                    .Single<RiskClaimDocument>(p => p.RiskID == selectedRiskId &&
                                    p.ClaimDocumentID == Guid.Parse(claimdocuments[i].ToString()));
                _context.RiskClaimDocuments.Remove(riskclaimdocument);
                await _context.SaveChangesAsync();
            }

            var updatedclaimdocuments = _context.ClaimDocuments
                                        .Where(i => !i.RiskClaimDocuments
                                        .Any(r => r.RiskID == selectedRiskId))
                                        .ToList();

            var updatedriskclaimdocuments = _context.RiskClaimDocuments
                                            .Include(r => r.ClaimDocument)
                                            .Where(r => r.RiskID == selectedRiskId)
                                            .ToList().Select(r => new SelectListItem
                                            {
                                                Value = r.ClaimDocumentID.ToString(),
                                                Text = r.ClaimDocument.Name
                                            });

            return Json(new { updatedclaimdocuments, updatedriskclaimdocuments });
        }

        [HttpPost]
        public IActionResult FillDocumentsListBoxes(string riskid)
        {
            int selectedRiskId = int.Parse(riskid);

            var claimdocuments = _context.ClaimDocuments
                                .Where(i => !i.RiskClaimDocuments
                                .Any(r => r.RiskID == selectedRiskId))
                                .ToList();

            var riskclaimdocuments = _context.RiskClaimDocuments
                                    .Include(r => r.ClaimDocument)
                                    .Where(r => r.RiskID == selectedRiskId)
                                    .ToList().Select(r => new SelectListItem
                                    {
                                        Value = r.ClaimDocumentID.ToString(),
                                        Text = r.ClaimDocument.Name
                                    });

            return Json(new { claimdocuments, riskclaimdocuments });
        }

        [HttpPost]
        public async Task<IActionResult> AddRiskIncidents (string riskId, string[] incidents)
        {
            int selectedRiskId = int.Parse(riskId);
            int ro = incidents.Count();
            RiskIncident riskincident = new RiskIncident();
            for (int i = 0; i < ro; i++)
            {
                riskincident.RiskID = selectedRiskId;
                riskincident.IncidentID = Guid.Parse(incidents[i].ToString());
                _context.Add(riskincident);
                await _context.SaveChangesAsync();
            }

            var updatedincidents = _context.Incidents
                            .Where(i => !i.RiskIncidents
                            .Any(r => r.RiskID == selectedRiskId))
                            .ToList();

            var updatedriskincidents = _context.RiskIncidents
                .Include(r => r.Incident)
                .Where(r => r.RiskID == selectedRiskId)
                .ToList().Select(r => new SelectListItem
                {
                    Value = r.IncidentID.ToString(),
                    Text = r.Incident.Name
                });

            return Json(new { updatedincidents, updatedriskincidents });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRiskIncidents(string riskId, string[] incidents)
        {
            int selectedRiskId = int.Parse(riskId);
            int ro = incidents.Count();
            RiskIncident riskincident = new RiskIncident();
            for (int i = 0; i < ro; i++)
            {
                riskincident = _context.RiskIncidents
                    .Single<RiskIncident>(p => p.RiskID == selectedRiskId &&
                        p.IncidentID == Guid.Parse(incidents[i].ToString()));
                _context.RiskIncidents.Remove(riskincident);
                await _context.SaveChangesAsync();
            }
            var updatedincidents = _context.Incidents
                            .Where(i => !i.RiskIncidents
                            .Any(r => r.RiskID == selectedRiskId))
                            .ToList();

            var updatedriskincidents = _context.RiskIncidents
                .Include(r => r.Incident)
                .Where(r => r.RiskID == selectedRiskId)
                .ToList().Select(r => new SelectListItem
                {
                    Value = r.IncidentID.ToString(),
                    Text = r.Incident.Name
                });

            return Json(new { updatedincidents, updatedriskincidents });
        }

        [HttpPost]
        public IActionResult FillListBoxes(string riskid)
        {
            int selectedRiskId = int.Parse(riskid);

            var incidents = _context.Incidents
                            .Where(i => !i.RiskIncidents
                            .Any(r => r.RiskID == selectedRiskId))
                            .ToList();

            var riskincidents = _context.RiskIncidents
                .Include(r => r.Incident)
                .Where(r => r.RiskID == selectedRiskId)
                .ToList().Select(r => new SelectListItem
                {
                    Value = r.IncidentID.ToString(),
                    Text = r.Incident.Name
                });
            
            return Json(new { incidents, riskincidents });
        }

        // GET: Risks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var risk = await _context.Risks.SingleOrDefaultAsync(m => m.ID == id);
            if (risk == null)
            {
                return NotFound();
            }

            return View(risk);
        }

        public async Task<IActionResult> RiskClaimDocument(int riskId)
        {
            int _riskId;
            var risks = _context.Risks.OrderBy(r => r.Name).ToList();

            _riskId = (riskId == 0) ? risks.FirstOrDefault().ID : riskId;

            var riskclaimdocuments = await _context.RiskClaimDocuments
                                    .Where(r => r.RiskID == _riskId)
                                    .Include(r => r.ClaimDocument)
                                    .ToListAsync();

            var claimdocuments = await _context.ClaimDocuments
                                .Where(i => !i.RiskClaimDocuments
                                .Any(r => r.RiskID == _riskId))
                                .ToListAsync();

            RiskClaimDocumentViewModel viewModel = new RiskClaimDocumentViewModel
            {
                Risks = new SelectList(risks, "ID", "Name", _riskId),
                RiskClaimDocumentList = new MultiSelectList(riskclaimdocuments, "ClaimDocumentID", "ClaimDocument.Name"),
                ClaimDocumentList = new MultiSelectList(claimdocuments, "ID", "Name")
            };
            return View(viewModel);
        }

        public async Task<IActionResult> RiskIncident(int riskId)
        {
            int selectedRiskId = 0;
            var risks = await _context.Risks.AsNoTracking().OrderBy(r => r.Name).ToListAsync();

            ViewBag.datasource0 = risks;

            selectedRiskId = (riskId == 0) ? risks.FirstOrDefault().ID : riskId;

            var riskincidents = await _context.RiskIncidents
                                    .Include(r => r.Incident)
                                    .AsNoTracking()
                                    .Where(r => r.RiskID == selectedRiskId)
                                    .ToListAsync();

            var incidents = await _context.Incidents
                                .AsNoTracking()
                                .Where(i => !i.RiskIncidents
                                .Any(r => r.RiskID == selectedRiskId))
                                .ToListAsync();

            ViewBag.datasource = incidents;
            ViewBag.data = riskincidents.Select(r => new
                                        { ID = r.IncidentID.ToString(), r.Incident.Name }).ToList();

            RiskIncidentViewModel viewModel = new RiskIncidentViewModel
            {
                Risks = new SelectList(risks, "ID", "Name", selectedRiskId),
                RiskIncidentList = new MultiSelectList(await _context.RiskIncidents
                                                                .AsNoTracking()
                                                                .Where(r => r.RiskID == selectedRiskId)
                                                                .Include(r => r.Incident)
                                                                .ToListAsync(), "IncidentID", "Incident.Name"),
                IncidentList = new MultiSelectList(await _context.Incidents
                                                            .AsNoTracking()
                                                            .Where(i => !i.RiskIncidents
                                                            .Any(r => r.RiskID == selectedRiskId))
                                                            .ToListAsync(), "ID", "Name")
            };
            return View(viewModel);
        }

        // GET: Risks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Risks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RiskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Risk risk = new Risk();
                risk = viewModel.Risk;
                // User to manually add ID on create new Risk
                //risk.ID = Guid.NewGuid();
                _context.Add(risk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Risks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var risk = await _context.Risks.SingleOrDefaultAsync(m => m.ID == id);
            if (risk == null)
            {
                return NotFound();
            }
            RiskViewModel viewModel = new RiskViewModel
            {
                Risk = risk
            };
            return View(risk);
        }

        // POST: Risks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RiskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Risk risk = viewModel.Risk;
                try
                {
                    _context.Update(risk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiskExists(risk.ID))
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
            return View(viewModel);
        }

        // GET: Risks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var risk = await _context.Risks.SingleOrDefaultAsync(m => m.ID == id);
            if (risk == null)
            {
                return NotFound();
            }

            return View(risk);
        }

        // POST: Risks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var risk = await _context.Risks.SingleOrDefaultAsync(m => m.ID == id);
            _context.Risks.Remove(risk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RiskExists(int id)
        {
            return _context.Risks.Any(e => e.ID == id);
        }
    }
}
