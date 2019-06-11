using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PremiumTempsViewModel
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int RiskID { get; set; }
        public string Reference { get; set; }
        public DateTime ReceivableDate { get; set; }
        public Guid PaymentTypeID { get; set; }
        public decimal PaymentAmount { get; set; }
        public string BatchNumber { get; set; }

        public decimal PremiumTotal { get; set; }
        public IEnumerable<PremiumTemp> PremiumTemps { get; set; }
    }
}
