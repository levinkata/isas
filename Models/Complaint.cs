using Isas.CustomAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Complaint
    {
        public Guid ID { get; set; }

        [Display(Name = "Complaint")]
        [StringLength(100), Required(ErrorMessage = "Complaint is required.")]
        public string Name { get; set; }

        [Display(Name = "Complaint Date")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime ComplaintDate { get; set; }

        public virtual ICollection<ComplaintDetail> ComplaintDetails { get; set; }
    }
}
