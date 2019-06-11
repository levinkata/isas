using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimClass
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Class")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Affect CFG")]
        public bool AffectCFG { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
