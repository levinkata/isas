using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimTransaction
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Number")]
        public int ClaimNumber { get; set; }

        [Display(Name = "Payee")]
        public Guid PayeeID { get; set; }

        [Display(Name ="Invoice Number")]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Requisition Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime RequisitionDate { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        [Range(1, 999999999, ErrorMessage = "Amount must be greater than 0")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Transaction Type")]
        public Guid TransactionTypeID { get; set; }

        [Display(Name = "Affected")]
        public Guid AffectedID { get; set; }

        [Display(Name = "Account Code")]
        public Guid AccountID { get; set; }

        [Display(Name = "Taxable")]
        public bool Taxable { get; set; }

        [Display(Name = "Tax Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Reserve Insured")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveInsured { get; set; }

        [Display(Name = "Reserve Third Party")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveThirdParty { get; set; }
        public int HoldForPayment { get; set; }
        public int PassForPayment { get; set; }

        [Display(Name = "Authorised")]
        public bool Authorised { get; set; }
        public Guid? AuthoriserID { get; set; }
        public Guid? PayableID { get; set; }

        [Display(Name = "Finalise")]
        public bool Finalise { get; set; }

        [Display(Name = "Transaction Number")]
        public int TransactionNumber { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual Payee Payee { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Affected Affected { get; set; }
        public virtual AccountChart Account { get; set; }
        public virtual Payable Payable { get; set; }
    }
}
