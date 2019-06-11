using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Bank
    {
        public Guid ID { get; set; }

        [Display(Name = "Bank")]
        [StringLength(50)]
        [Required(ErrorMessage ="Bank Name is required.")]
        public string Name { get; set; }
        
        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }

        public virtual ICollection<BankBranch> BankBranches { get; set; }
    }
}
