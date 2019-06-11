using System;

namespace Isas.Models
{
    public class RiskClaimDocument
    {
        public int RiskID { get; set; }
        public Guid ClaimDocumentID { get; set; }

        public virtual Risk Risk { get; set; }
        public virtual ClaimDocument ClaimDocument { get; set; }
    }
}
