using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PremiumType
    {
        public Guid ID { get; set; }

        [Display(Name = "Premium Type")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Premium> Premiums { get; set; }
    }
}
