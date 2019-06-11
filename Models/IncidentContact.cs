using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class IncidentContact
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Number")]
        public int ClaimNumber { get; set; }

        [Display(Name = "Issue Date")]
        [DataType(DataType.Date), Required(ErrorMessage = "Issue Date is mandatory")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Phone")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        [StringLength(50)]
        public string Mobile { get; set; }

        [Display(Name = "Authoriser")]
        public Guid AuthoriserID { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual Claim Claim { get; set; }
    }
}
