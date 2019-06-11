using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class TracingAgent
    {
        public Guid ID { get; set; }

        [Display(Name = "Tracing Agent")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tracing Agent Name is required.")]
        public string Name { get; set; }

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }

        public virtual ICollection<ClaimTracingAgent> ClaimTracingAgents { get; set; }
    }
}
