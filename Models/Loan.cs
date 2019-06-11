using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Loan
    {
        public Guid ID { get; set; }
        public Guid PolicyID { get; set; }
        public Guid ComponentID { get; set; }

        [Display(Name = "Account Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber { get; set; }

        [Display(Name = "Term")]
        [Required(ErrorMessage = "Term is required")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Term { get; set; }

        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Rate is required")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Rate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [Display(Name = "Loan Date")]
        [Required(ErrorMessage = "Loan Date is required")]
        public DateTime LoanDate { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Value is required")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium")]
        [Required(ErrorMessage = "Premium is required")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Premium { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [Display(Name = "Settlement Date")]
        //[Required(ErrorMessage = "Settlement Date is required")]
        public DateTime? SettlementDate { get; set; }

        [Display(Name = "Policy Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Insurer Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal InsurerFee { get; set; }

        [Display(Name = "Commission")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Commission { get; set; }

        [Display(Name = "Admin Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal AdminFee { get; set; }
        public int BulkHandle { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual Component Component { get; set; }
    }
}
