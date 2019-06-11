using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class ClaimRecovery
    {
        public Guid ID { get; set; }

        [Display(Name="Claim Number")]
        public int ClaimNumber { get; set; }

        [Display(Name = "Third Party")]
        public Guid ThirdPartyID { get; set; }

        [Display(Name = "Reference")]
        [Required, StringLength(50)]
        public string Reference { get; set; }

        [Display(Name = "Recovery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime RecoveryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Recovery")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Received")]
        public Guid? PaymentReceivedID { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual ThirdParty ThirdParty { get; set; }
    }
}
