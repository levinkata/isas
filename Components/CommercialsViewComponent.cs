using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class CommercialsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public CommercialsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var commercials = await _context.Commercials
                                    .Include(c => c.Component)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.Component.Name).ToListAsync();

            CommercialsViewModel viewModel = new CommercialsViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                Commercials = commercials
            };
            return View(viewModel);
        }
    }
}
