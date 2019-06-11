using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Region
    {
        public Guid ID { get; set; }

        [Display(Name = "Region")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
