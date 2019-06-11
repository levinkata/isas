using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PolicyFrequency
    {
        public Guid ID { get; set; }

        [Display(Name = "Frequency")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Installments")]
        [Range(1, 12)]
        public int Divisor { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
