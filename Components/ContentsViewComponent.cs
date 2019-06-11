using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class ContentsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public ContentsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var contents = await _context.Contents
                                    .Include(a => a.Policy)
                                    .Include(a => a.ResidenceType)
                                    .Include(a => a.WallType)
                                    .Include(a => a.RoofType)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.Location).ToListAsync();

            ContentsViewModel viewModel = new ContentsViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                Contents = contents
            };
            return View(viewModel);
        }
    }
}
