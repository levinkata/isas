using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimDiary
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Number")]
        public int ClaimNumber { get; set; }

        [Display(Name = "Activity")]
        [StringLength(100)]
        public string Activity { get; set; }

        [Display(Name = "Activity Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime ActivityDate { get; set; }

        [Display(Name = "Document Path")]
        [StringLength(100)]
        public string DocumentPath { get; set; }

        public virtual Claim Claim { get; set; }
    }
}
