using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Models
{
    public class ComplaintDetail
    {
        public Guid ID { get; set; }
        public Guid ComplaintID { get; set; }

        [Display(Name = "Complaint Detail")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Complaint Detail Date")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime ComplaintDetailDate { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
