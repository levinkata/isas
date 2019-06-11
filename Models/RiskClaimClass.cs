using System;

namespace Isas.Models
{
    public class RiskClaimClass
    {
        public int RiskID { get; set; }
        public Guid ClaimClassID { get; set; }

        public virtual Risk Risk { get; set; }
        public virtual ClaimClass ClaimClass { get; set; }
    }
}
