using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Payable
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }

        [Display(Name = "Reference")]
        [StringLength(50)]
        [Required(ErrorMessage = "Reference is required.")]
        public string Reference { get; set; }

        [Display(Name = "Payable Date")]
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime PayableDate { get; set; }

        [Display(Name = "Payment Type")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }
        
        [Display(Name = "Batch Number")]
        [StringLength(50)]
        public string BatchNumber { get; set; }

        [Display(Name = "Void")]
        public bool Void { get; set; }

        [Display(Name = "Void Reason")]
        [StringLength(100)]
        public string VoidReason { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(50)]
        public string Remarks { get; set; }

        [Display(Name = "Export")]
        public Guid? PayableExportID { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<ClaimTransaction> ClaimTransaction { get; set; }
    }
}
