using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class LoanTempsViewModel
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public Guid ComponentID { get; set; }
        public decimal PremiumTotal { get; set; }
        public decimal LoanTotal { get; set; }
        public IEnumerable<LoanTemp> LoanTemps { get; set; }
    }
}
