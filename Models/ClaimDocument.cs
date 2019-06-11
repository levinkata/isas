using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClaimDocument
    {
        public Guid ID { get; set; }

        [Display(Name = "Document")]
        [StringLength(50)]
        [Required(ErrorMessage ="Document is required")]
        public string Name { get; set; }

        [Display(Name ="Mandatory")]
        public bool Mandatory { get; set; }

        public virtual ICollection<ClaimDocumentSubmit> ClaimDocumentSubmits { get; set; }
        public virtual ICollection<RiskClaimDocument> RiskClaimDocuments { get; set; }        
    }
}
