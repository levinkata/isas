using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class PolicyRiskTotalsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public PolicyRiskTotalsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid policyId)
        {
            var risks = await _context.Risks.ToListAsync();

            PolicyRiskTotalsViewModel viewModel = new PolicyRiskTotalsViewModel
            {
                PolicyID = policyId,
                Risks = risks,
                PremiumTotals = PremiumTotals(policyId),
                SumInsuredTotals = SumInsuredTotals(policyId)
            };
            return View(viewModel);
        }

        private decimal PremiumTotals(Guid policyId)
        {
            decimal TotalPremiums = 0;

            decimal allriskpremium = (from a in _context.AllRisks
                                      where a.PolicyID == policyId
                                      select a.Premium).Sum();

            decimal commercialpremium = (from c in _context.Commercials
                                         where c.PolicyID == policyId
                                         select c.Premium).Sum();

            decimal contentpremium = (from c in _context.Contents
                                      where c.PolicyID == policyId
                                      select c.Premium).Sum();

            decimal loanpremium = (from l in _context.Loans
                                   where l.PolicyID == policyId
                                   select l.Premium).Sum();

            decimal motorpremium = (from m in _context.Motors
                                    where m.PolicyID == policyId
                                    select m.Premium).Sum();

            decimal propertypremium = (from p in _context.Properties
                                       where p.PolicyID == policyId
                                       select p.Premium).Sum();

            decimal Totals = allriskpremium + commercialpremium +
                                    contentpremium + loanpremium +
                                    motorpremium + propertypremium;
            if (Totals > 0)
                TotalPremiums = Totals;

            return TotalPremiums;
        }

        private decimal SumInsuredTotals(Guid policyId)
        {
            decimal TotalValues = 0;

            decimal allriskvalue = (from a in _context.AllRisks
                                    where a.PolicyID == policyId
                                    select a.Value).Sum();

            decimal commercialvalue = (from c in _context.Commercials
                                       where c.PolicyID == policyId
                                       select c.Value).Sum();

            decimal contentvalue = (from c in _context.Contents
                                    where c.PolicyID == policyId
                                    select c.Value).Sum();

            decimal loanvalue = (from l in _context.Loans
                                 where l.PolicyID == policyId
                                 select l.Value).Sum();

            decimal motorvalue = (from m in _context.Motors
                                  where m.PolicyID == policyId
                                  select m.Value).Sum();

            decimal propertyvalue = (from p in _context.Properties
                                     where p.PolicyID == policyId
                                     select p.Value).Sum();

            decimal Totals = allriskvalue + commercialvalue +
                                    contentvalue + loanvalue +
                                    motorvalue + propertyvalue;
            if (Totals > 0)
                TotalValues = Totals;

            return TotalValues;
        }
    }
}
