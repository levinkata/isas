using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class PremiumTemp
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int RiskID { get; set; }

        [Display(Name = "ID Number")]
        [StringLength(50)]
        public string IDNumber { get; set; }

        [StringLength(50)]
        public string Reference { get; set; }

        [Display(Name = "Receivable Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime ReceivableDate { get; set; }
        public Guid PaymentTypeID { get; set; }

        [Display(Name = "Payment Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PaymentAmount { get; set; }

        [StringLength(50)]
        public string BatchNumber { get; set; }
        
        [Display(Name = "Premium Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime? PremiumDate { get; set; }

        [Display(Name = "Type")]
        public Guid PremiumTypeID { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Policy Fee")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Commission")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Commission { get; set; }

        [Display(Name = "Admin Fee")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal AdminFee { get; set; }
        public virtual PremiumType PremiumType { get; set; }

    }
}
