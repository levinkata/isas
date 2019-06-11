using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyRiskTotalsViewModel
    {
        public Guid PolicyID { get; set; }
        public IEnumerable<Risk> Risks { get; set; }
        public decimal PremiumTotals { get; set; }
        public decimal SumInsuredTotals { get; set; }
    }
}
