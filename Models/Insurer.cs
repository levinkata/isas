using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Insurer
    {
        public Guid ID { get; set; }

        [Display(Name = "Insurer")]
        [StringLength(50)]
        [Required(ErrorMessage ="Insurer Name is required.")]
        public string Name { get; set; }

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
