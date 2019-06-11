using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PolicyHistory
    {
        public Guid ID { get; set; }
        public Guid HistoryID { get; set; }
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerID { get; set; }

        [Display(Name = "Insurer Number")]
        public string InsurerNumber { get; set; }

        [Display(Name = "Frequency")]
        public Guid PolicyFrequencyID { get; set; }

        [Display(Name = "Cover Start Date")]
        public DateTime CoverStartDate { get; set; }

        [Display(Name = "Cover End Date")]
        public DateTime CoverEndDate { get; set; }

        [Display(Name = "Status")]
        public Guid PolicyStatusID { get; set; }

        [Display(Name = "Status Date")]
        public DateTime? StatusDate { get; set; }

        [Display(Name = "Premium Due Date")]
        public DateTime? PremiumDueDate { get; set; }

        [Display(Name = "Version")]
        public int PolicyVersion { get; set; }

        [Display(Name = "Inception Date")]
        public DateTime? InceptionDate { get; set; }

        [Display(Name = "Renewable")]
        public bool Renewable { get; set; }
        public Guid IncomeClassID { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public int BulkHandle { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
