using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class PremiumsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public PremiumsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId, Guid clientId, Guid policyId)
        {
            var premiums = await (from p in _context.Premiums
                                .Include(p => p.Policy)
                                .Include(t => t.PremiumType)
                                .Include(r => r.Receivable)
                                    .ThenInclude(p => p.PaymentType)
                                .AsNoTracking()
                                  where p.PolicyID == policyId
                                  orderby p.PremiumDate
                                  select p).ToListAsync();

            PremiumsViewModel viewModel = new PremiumsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Premiums = premiums
            };
            return View(viewModel);
        }
    }
}
