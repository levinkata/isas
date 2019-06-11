using System;

namespace Isas.Models
{
    public class ClaimRepairer
    {
        public Guid ClaimNumber { get; set; }
        public Guid RepairerID { get; set; }

        public virtual Repairer Repairer{ get; set; }
        public virtual Claim Claim { get; set; }
    }
}
