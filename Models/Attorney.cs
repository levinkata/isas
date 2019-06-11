using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Attorney
    {
        public Guid ID { get; set; }

        [Display(Name = "Attorney")]
        [StringLength(100)]
        [Required(ErrorMessage = "Attorney Name is required.")]
        public string Name { get; set; }

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }

        public virtual ICollection<ClaimAttorney> ClaimAttorneys { get; set; }
    }
}
