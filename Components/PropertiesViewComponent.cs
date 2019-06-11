using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class PropertiesViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public PropertiesViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var properties = await _context.Properties
                                    .Include(a => a.Policy)
                                    .Include(a => a.Coverage)
                                    .Include(a => a.ResidenceType)
                                    .Include(a => a.WallType)
                                    .Include(a => a.RoofType)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.Location).ToListAsync();

            PropertiesViewModel viewModel = new PropertiesViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                Properties = properties
            };
            return View(viewModel);
        }
    }
}
