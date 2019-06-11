using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class LossAdjuster
    {
        public Guid ID { get; set; }

        [Display(Name = "Loss Adjuster")]
        [StringLength(100)]
        [Required(ErrorMessage = "Loss Adjuster Name is required.")]
        public string Name { get; set;}

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }
        public virtual ICollection<ClaimLossAdjuster> ClaimLossAdjusters { get; set; }
    }
}
