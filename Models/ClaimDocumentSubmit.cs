using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimDocumentSubmit
    {
        public Guid ID { get; set; }

        [Display(Name = "Claim Number")]
        public int ClaimNumber { get; set; }
        public Guid ClaimDocumentID { get; set; }

        [Display(Name = "Date Submitted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime? SubmitDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual ClaimDocument ClaimDocument { get; set; }
    }
}
