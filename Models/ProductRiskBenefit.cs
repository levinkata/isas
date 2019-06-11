using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ProductRiskBenefit
    {
        public Guid ID { get; set; }
        public Guid ProductRiskID { get; set; }

        [Required, Display(Name = "Benefit")]
        [StringLength(50)]
        public string Benefit { get; set; }

        public virtual ProductRisk ProductRisk { get; set; }
    }
}
