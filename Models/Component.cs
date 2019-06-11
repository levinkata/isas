using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Component
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Component")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<AllRisk> AllRisks { get; set; }
        public virtual ICollection<Commercial> Commercials { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
