using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class AllRisksViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public AllRisksViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var allrisks = await _context.AllRisks
                                    .Include(a => a.Component)
                                    .Include(a => a.Policy)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.Component.Name).ToListAsync();

            AllRisksViewModel viewModel = new AllRisksViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                AllRisks = allrisks
            };
            return View(viewModel);
        }
    }
}
