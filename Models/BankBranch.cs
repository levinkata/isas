using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class BankBranch
    {
        public Guid ID { get; set; }
        public Guid BankID { get; set; }

        [Display(Name = "Branch")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Branch Code")]
        [StringLength(50)]
        public string BIC { get; set; }

        [Display(Name = "Swift Code")]
        [StringLength(50)]
        public string SwiftCode { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
