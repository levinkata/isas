using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class BankAccount
    {
        public Guid ID { get; set; }

        [Display(Name = "Branch")]
        public Guid BankBranchID { get; set; }

        [Display(Name = "Account Number")]
        [Required, StringLength(50)]
        public string AccountNumber { get; set; }

        public virtual BankBranch BankBranch { get; set; }
        public virtual ICollection<PayeeBankAccount> PayeeBankAccount { get; set; }
        public virtual ICollection<PolicyBankAccount> PolicyBankAccounts { get; set; }
    }
}
