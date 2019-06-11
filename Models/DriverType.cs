using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class DriverType
    {
        public Guid ID { get; set; }

        [Display(Name = "Driver Type")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Motor> Motors { get; set; }
    }
}
