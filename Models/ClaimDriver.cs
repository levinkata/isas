using System;

namespace Isas.Models
{
    public class ClaimDriver
    {
        public Guid ClaimNumber { get; set; }
        public Guid DriverID { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
