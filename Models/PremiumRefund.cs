using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class PremiumRefund
    {
        public Guid ID { get; set; }
        public Guid PremiumID { get; set; }

        [Display(Name = "Requisition Date")]
        [DataType(DataType.Date)]
        public DateTime RequsitionDate { get; set; }

        [Display(Name = "Refund Date")]
        [DataType(DataType.Date)]
        public DateTime RefundDate { get; set; }

        [Display(Name = "Refund")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Account")]
        public Guid AccountID { get; set; }

        [Display(Name = "Reference")]
        [StringLength(50)]
        public string Reference { get; set; }

        [Display(Name = "Authorised")]
        public bool IsAuthorised { get; set; }

        [Display(Name = "Authoriser")]
        public Guid AuthoriserID { get; set; }

        [Display(Name = "Paid")]
        public Guid PaymentMadeID { get; set; }

        [Display(Name = "Batch")]
        public string BatchNumber { get; set; }

        public virtual AccountChart Account { get; set; }
        public virtual Premium Premium { get; set; }
    }
}
