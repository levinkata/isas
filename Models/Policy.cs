using Isas.CustomAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Policy
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }

        [StringLength(50)]
        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerID { get; set; }

        [StringLength(50)]
        [Display(Name = "Insurer Number")]
        public string InsurerNumber { get; set; }

        [Display(Name = "Frequency")]
        public Guid PolicyFrequencyID { get; set; }

        [Display(Name = "Policy Effective Date")]
        [Required(ErrorMessage = "Policy Effective Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DateTimeCompare("ExpireDate", ValueComparison.IsLessThan,
            ErrorMessage = "Policy Effective Date must be earlier than Cover End Date.")]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "Policy Expire Date")]
        [Required(ErrorMessage = "Policy Expire Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DateTimeCompare("EffectiveDate", ValueComparison.IsGreaterThan,
            ErrorMessage = "Policy Expire Date must be later than Cover Start Date.")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "Status")]
        public Guid PolicyStatusID { get; set; }

        [Display(Name = "Status Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime StatusDate { get; set; }

        [Display(Name = "Premium Due Date")]
        [Required(ErrorMessage = "Premium Due Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime PremiumDueDate { get; set; }

        [Display(Name = "Version")]
        [Range(1, 99, ErrorMessage = "Required range is between 1 and 99.")]
        public int PolicyVersion { get; set; }

        [Display(Name = "Inception Date")]
        [Required(ErrorMessage = "Inception Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime InceptionDate { get; set; }

        [Display(Name = "Renewable")]
        public bool Renewable { get; set; }

        [Display(Name = "Income Class")]
        public Guid IncomeClassID { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public int BulkHandle { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Client Client { get; set; }
        public virtual Insurer Insurer { get; set; }
        public virtual IncomeClass IncomeClass { get; set; }
        public virtual PolicyFrequency PolicyFrequency { get; set; }
        public virtual PolicyStatus PolicyStatus { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Premium> Premiums { get; set; }
        public virtual ICollection<PolicyBankAccount> PolicyBankAccount { get; set; }
        public virtual ICollection<AllRisk> AllRisk { get; set; }
        public virtual ICollection<Commercial> Commercial { get; set; }
        public virtual ICollection<Content> Content { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<Motor> Motor { get; set; }
        public virtual ICollection<Property> Property { get; set; }

    }
}
