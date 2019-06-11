using System;

namespace Isas.Models
{
    public class ClaimTracingAgent
    {
        public Guid ClaimNumber { get; set; }
        public Guid TracingAgentID { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual TracingAgent TracingAgent { get; set; }
    }
}
