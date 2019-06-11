using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Receivable
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }

        [Display(Name = "Reference")]
        [StringLength(50), Required(ErrorMessage = "Reference is mandatory.")]
        public string Reference { get; set; }

        [Display(Name = "Receivable Date")]
        [DataType(DataType.Date), Required(ErrorMessage = "Receivable Date is mandatory")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime ReceivableDate { get; set; }

        [Display(Name = "Type")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Premium> Premiums { get; set; }
    }
}
