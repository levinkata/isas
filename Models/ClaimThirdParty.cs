using System;

namespace Isas.Models
{
    public class ClaimThirdParty
    {
        public int ClaimNumber { get; set; }
        public Guid ThirdPartyID { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual ThirdParty ThirdParty { get; set; }
    }
}
