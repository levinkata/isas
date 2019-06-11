using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class ClaimTransactionsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public ClaimTransactionsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId, Guid clientId, Guid policyId, int claimNumber)
        {
            var claimtransactions = await _context.ClaimTransactions
                                    .Include(c => c.Account)
                                    .Include(c => c.Affected)
                                    .Include(c => c.Claim)
                                    .Include(c => c.Payee)
                                    .Include(c => c.TransactionType)
                                    .AsNoTracking()
                                    .Where(t => t.ClaimNumber == claimNumber)
                                    .OrderBy(t => t.TransactionNumber)
                                    .ToListAsync();

            ClaimTransactionsViewModel viewModel = new ClaimTransactionsViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                ClaimNumber = claimNumber,
                ClaimTransactions = claimtransactions
            };

            return View(viewModel);
        }
    }
}
