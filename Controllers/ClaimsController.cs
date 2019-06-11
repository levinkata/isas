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
    [Authorize]
    public class ClaimsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClaimsController(InsurerDbContext context)
        {
            _context = context;    
        }

        public IActionResult AddClaimPolicyRisk(Guid productid, Guid policyid, Guid clientid)
        {
            SelectedPolicyRisk viewModel = new SelectedPolicyRisk
            {
                ContainerID = Guid.Empty,
                ProductID = productid,
                ClientID = clientid,
                PolicyID = policyid
            };
            return View(viewModel);
        }

        // POST: Claims/AddClaimPolicyRisk/5
        [HttpPost, ActionName("AddClaimPolicyRisk")]
        [ValidateAntiForgeryToken]
        public IActionResult AddClaimPolicyRiskConfirmed(SelectedPolicyRisk selectedpolicyrisk)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Create",
                    new
                    {
                        containerid = selectedpolicyrisk.ContainerID,
                        policyriskid = selectedpolicyrisk.PolicyRiskID,
                        policyid = selectedpolicyrisk.PolicyID,
                        clientid = selectedpolicyrisk.ClientID,
                        productid = selectedpolicyrisk.ProductID
                    });
            }
            return View(selectedpolicyrisk);
        }
        
        // GET: Claims
        public async Task<IActionResult> Index(Guid productId, Guid clientId, Guid policyId)
        {
            var claims = await (from c in _context.Claims
                            .Include(c => c.ClaimClass)
                            .Include(c => c.ClaimStatus)
                            .Include(c => c.Incident)
                            .Include(c => c.Region)
                            .OrderBy(r => r.ClaimNumber)
                            .Where(c => c.PolicyID == policyId)
                         select c).ToListAsync();

            ClaimsViewModel viewModel = new ClaimsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Claims = claims
            };

            return View(viewModel);
        }

        // GET: Claims/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var claim = await _context.Claims.SingleOrDefaultAsync(m => m.ClaimNumber == id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        // GET: Claims/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId, int riskId, Guid riskitemId)
        {
            Models.Claim claim = new Models.Claim
            {
                RiskID = riskId,
                RiskItemID = riskitemId,
                RegisterDate = DateTime.Now,
                IncidentDate = DateTime.Now,
                ReportDate = DateTime.Now
            };

            ClaimViewModel viewModel = new ClaimViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Claim = claim,
                ClaimClassList = new SelectList(await _context.ClaimClasses.AsNoTracking().ToListAsync(), "ID", "Name",
                                                await _context.ClaimClasses.FirstOrDefaultAsync()),
                ClaimStatusList = new SelectList(await _context.ClaimStatuses.AsNoTracking().ToListAsync(), "ID", "Name",
                                                await _context.ClaimStatuses.FirstOrDefaultAsync()),
                IncidentList = new SelectList(await _context.Incidents
                                                .Where(i => i.RiskIncidents.Any(r => r.RiskID == riskId))
                                                .AsNoTracking().ToListAsync(),
                                                "ID", "Name", await _context.Incidents.FirstOrDefaultAsync()),
                RegionList = new SelectList(await _context.Regions.AsNoTracking().ToListAsync(), "ID", "Name",
                                            await _context.Regions.FirstOrDefaultAsync()),
                ProvinceList = new SelectList(await _context.Provinces.OrderBy(n => n.Name).AsNoTracking().ToListAsync(), "ID", "Name",
                                            await _context.Provinces.FirstOrDefaultAsync()),
                CountryList = new SelectList(await _context.Countries.OrderBy(n => n.Name).AsNoTracking().ToListAsync(), "ID", "Name",
                                            await _context.Countries.FirstOrDefaultAsync())
            };
            return View(viewModel);
        }

        // POST: Claims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //  Check if Claim Series has been set
                int claimPrefix = GetClaimPrefix(viewModel.PolicyID, viewModel.Claim.RiskID);
                if (claimPrefix > 0)
                {
                    //Random rnd = new Random();
                    Models.Claim claim = viewModel.Claim;
                    var riskId = viewModel.Claim.RiskID;
                    claim.ClaimNumber = GetClaimNumber(claimPrefix);
                    claim.PolicyID = viewModel.PolicyID;
                    claim.ReserveInsuredRevised = claim.ReserveInsured;
                    claim.ReserveThirdPartyRevised = claim.ReserveThirdParty;
                    _context.Add(claim);
                    await _context.SaveChangesAsync();

                    var claimNumber = claim.ClaimNumber;
                    var myParams = new object[] { claimPrefix, claimNumber };

                    await _context.Database.ExecuteSqlCommandAsync(
                                                "INSERT INTO ClaimNumberGenerator(ClaimPrefix, ClaimNumber) " +
                                                "Values ({0}, {1})",
                                                parameters: myParams);
                    
                    Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                    var riskclaimdocuments = _context.RiskClaimDocuments.Where(r => r.RiskID == riskId);

                    if (riskclaimdocuments.Count() > 0)
                    {
                        foreach (var r in riskclaimdocuments)
                        {
                            var claimParams = new object[] { Guid.NewGuid(), claim.ClaimNumber, r.ClaimDocumentID, null, DateTime.Now,
                                                     currentUserId, null, null};

                            await _context.Database.ExecuteSqlCommandAsync(
                                                        "INSERT INTO ClaimDocumentSubmit(ID, ClaimNumber, ClaimDocumentID, SubmitDate, " +
                                                        "DateAdded, AddedBy, DateModified, ModifiedBy) " +
                                                        "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                                                        parameters: claimParams);
                        }
                    }
                    return RedirectToAction("Index", new {
                        productId = viewModel.ProductID, clientId = viewModel.ClientID, policyid = viewModel.PolicyID });
                }
                else
                {
                    ViewData["ErrorMessage"] = "Claim Number series not set";
                    viewModel.ClaimClassList = new SelectList(await _context.ClaimClasses.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.ClaimClassID);
                    viewModel.ClaimStatusList = new SelectList(await _context.ClaimStatuses.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.ClaimStatusID);
                    viewModel.IncidentList = new SelectList(await _context.Incidents
                                                            .Where(i => i.RiskIncidents.Any(r => r.RiskID == viewModel.Claim.RiskID))
                                                            .AsNoTracking().ToListAsync(),
                                                            "ID", "Name", viewModel.Claim.IncidentID);
                    viewModel.RegionList = new SelectList(await _context.Regions.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.RegionID);
                    return View(viewModel);
                }
            }
            viewModel.ClaimClassList = new SelectList(await _context.ClaimClasses.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.ClaimClassID);
            viewModel.ClaimStatusList = new SelectList(await _context.ClaimStatuses.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.ClaimStatusID);
            viewModel.IncidentList = new SelectList(await _context.Incidents
                                                    .Where(i => i.RiskIncidents.Any(r => r.RiskID == viewModel.Claim.RiskID))
                                                    .AsNoTracking().ToListAsync(),
                                                    "ID", "Name", viewModel.Claim.IncidentID);
            viewModel.RegionList = new SelectList(await _context.Regions.AsNoTracking().ToListAsync(), "ID", "Name", viewModel.Claim.RegionID);
            return View(viewModel);
        }

        // GET: Claims/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var claim = await _context.Claims.SingleOrDefaultAsync(m => m.ClaimNumber == id);
            if (claim == null)
            {
                return NotFound();
            }
            ClaimViewModel viewModel = new ClaimViewModel
            {
                Claim = claim,
                ClaimClassList = new SelectList(_context.ClaimClasses, "ID", "Name", claim.ClaimClassID),
                ClaimStatusList = new SelectList(_context.ClaimStatuses, "ID", "Name", claim.ClaimStatusID),
                IncidentList = new SelectList(_context.Incidents, "ID", "Name", claim.IncidentID),
                RegionList = new SelectList(_context.Regions, "ID", "Name", claim.RegionID)
            };
            return View(viewModel);
        }

        // POST: Claims/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClaimViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Models.Claim claim = new Models.Claim();
                    claim = viewModel.Claim;
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(viewModel.Claim.ClaimNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { policyId  = viewModel.Claim.PolicyID});
            }
            viewModel.ClaimClassList = new SelectList(_context.ClaimClasses, "ID", "Name", viewModel.Claim.ClaimClassID);
            viewModel.ClaimStatusList = new SelectList(_context.ClaimStatuses, "ID", "Name", viewModel.Claim.ClaimStatusID);
            viewModel.IncidentList = new SelectList(_context.Incidents, "ID", "Name", viewModel.Claim.IncidentID);
            viewModel.RegionList = new SelectList(_context.Regions, "ID", "Name", viewModel.Claim.RegionID);
            return View(viewModel);
        }

        // GET: Claims/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var claim = await _context.Claims.SingleOrDefaultAsync(m => m.ClaimNumber == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claim = await _context.Claims.SingleOrDefaultAsync(m => m.ClaimNumber == id);
            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { policyId = claim.PolicyID });
        }

        private int GetClaimPrefix(Guid PolicyId, int riskId)
        {
            int claimPrefix = 0;
            //Guid productId = _context.Policies.Single(p => p.ID == PolicyId).ProductID;

            //if (productId != null)
            //{
            //    claimPrefix = _context.ProductRisks.Single(p => p.ProductID == productId &&
            //                        p.RiskID == riskId).ClaimPrefix;
            //}
            return claimPrefix;
        }

        private int GetClaimNumber(int claimNumberPrefix)
        {
            int seedNumber = 0;

            int currentClaimNumbers = _context.ClaimNumberGenerators.Where(c => c.ClaimPrefix == claimNumberPrefix).Count();

            //if (currentClaimNumbers == 0)
            //{
            //    seedNumber = (claimNumberPrefix * 1000000) + 1;
            //}
            //else
            //{
            //    seedNumber = _context.ClaimNumberGenerators.Where(c => c.ClaimPrefix == claimNumberPrefix).Max(c => c.ClaimNumber);
            //}
            
            //return (seedNumber > 0) ? seedNumber + 1 : (claimNumberPrefix * 1000000) + 1;

            seedNumber = (currentClaimNumbers == 0) ? (claimNumberPrefix * 1000000) :
                _context.ClaimNumberGenerators.Where(c => c.ClaimPrefix == claimNumberPrefix).Max(n => n.ClaimNumber);

            return seedNumber = seedNumber + 1;
        }

        private bool ClaimExists(int id)
        {
            return _context.Claims.Any(e => e.ClaimNumber == id);
        }
    }
}
