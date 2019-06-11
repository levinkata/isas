using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Coverage
    {
        public Guid ID { get; set; }

        [Display(Name = "Coverage")]
        [Required, StringLength(50)]
        public string Name { get;set;}

        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Motor> Motors { get; set; }
    }
}
