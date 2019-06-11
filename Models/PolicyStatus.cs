using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PolicyStatus
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        [Required, Display(Name = "Status")]
        public string Name { get; set; }

        [Display(Name = "Updatable")]
        public bool Updatable { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
