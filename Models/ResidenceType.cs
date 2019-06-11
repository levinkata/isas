using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ResidenceType
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Residence")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
