using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class LoansViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public LoansViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var loans = await _context.Loans
                                    .Include(c => c.Component)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.Component.Name).ToListAsync();

            LoansViewModel viewModel = new LoansViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                Loans = loans
            };
            return View(viewModel);
        }
    }
}
