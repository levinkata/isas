using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimStatus
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Status")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name="Updatable")]
        public bool Updatable { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
