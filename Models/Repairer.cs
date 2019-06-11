using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Repairer
    {
        public Guid ID { get; set; }

        [Display(Name = "Repairer")]
        [StringLength(100)]
        [Required(ErrorMessage = "Repairer Name is required.")]
        public string Name { get; set; }

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }

        public virtual ICollection<ClaimRepairer> ClaimRepairers { get; set; }
    }
}
