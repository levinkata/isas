using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class ClaimLossAdjuster
    {
        public Guid ClaimNumber { get; set; }
        public Guid LossAdjusterID { get; set; }

        [Display(Name = "Claim Excess")]
        [DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18,2)")]
        public decimal ClaimExcess { get; set; }

        [Display(Name = "Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Display(Name = "Agree Repairs")]
        public bool AgreeRepair { get; set; }

        [Display(Name ="Agree Costs")]
        public bool AgreeCost { get; set; }

        public virtual LossAdjuster LossAdjuster { get; set; }
    }
}
