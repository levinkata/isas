using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class ProductRisk
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public int RiskID { get; set; }

        [Display(Name = "Claim Limit")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ClaimLimit { get; set; }

        [Display(Name = "Claim Prefix")]
        [Range(10,99, ErrorMessage = "Required range is between 10 and 99.")]
        public int ClaimPrefix { get; set; }

        [Display(Name = "Use CFG?")]
        public bool UseCFG { get; set; }

        [Display(Name = "Policy Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Commission")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Commission { get; set; }

        [Display(Name = "Admin Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal AdminFee { get; set; }

        public virtual Product Product { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual ICollection<ProductRiskBenefit> ProductRiskBenefits { get; set; }
    }
}
