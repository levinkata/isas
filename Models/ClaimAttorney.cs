using System;

namespace Isas.Models
{
    public class ClaimAttorney
    {
        public Guid ClaimNumber { get; set; }
        public Guid AttorneyID { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual Attorney Attorney { get; set; }
    }
}
