using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PolicyTemp
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerID { get; set; }

        [Display(Name = "Insurer Number")]
        public string InsurerNumber { get; set; }

        [Display(Name = "Frequency")]
        public Guid PolicyFrequencyID { get; set; }

        [Display(Name = "Policy Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "Policy Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Status")]
        public Guid PolicyStatusID { get; set; }

        [Display(Name = "Status Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StatusDate { get; set; }

        [Display(Name = "Premium Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PremiumDueDate { get; set; }

        [Display(Name = "Version")]
        public int PolicyVersion { get; set; }

        [Display(Name = "Inception Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? InceptionDate { get; set; }

        [Display(Name = "Renewable")]
        public bool Renewable { get; set; }

        public virtual Insurer Insurer { get; set; }
        public virtual PolicyFrequency PolicyFrequency { get; set; }
        public virtual PolicyStatus PolicyStatus { get; set; }
    }
}
