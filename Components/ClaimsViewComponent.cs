using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class ClaimsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public ClaimsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId, Guid clientId, Guid policyId)
        {
            var claims = await (from c in _context.Claims
                                        .Include(c => c.ClaimClass)
                                        .Include(c => c.ClaimStatus)
                                        .Include(c => c.Incident)
                                        .Include(c => c.Region)
                                        .AsNoTracking()
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
    }
}
