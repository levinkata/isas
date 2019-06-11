using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class IncomeClass
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Income Class")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
