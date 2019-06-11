using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class LoanTemp
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Display(Name = "Component")]
        public Guid ComponentID { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Term")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Term { get; set; }

        [Display(Name = "Rate")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Rate { get; set; }

        [Display(Name = "Loan Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LoanDate { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Premium { get; set; }

        [Display(Name = "Settlement Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? SettlementDate { get; set; }

        public virtual Component Component { get; set; }
    }
}
