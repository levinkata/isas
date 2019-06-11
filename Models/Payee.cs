using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Payee
    {
        public Guid ID { get; set; }
        public int PayeeClassID { get; set; }
        public Guid PayeeItemID { get; set; }

        [Display(Name = "Payee")]
        public string Name { get; set; }

        public virtual PayeeClass PayeeClass { get; set; }
        public virtual ICollection<ClaimTransaction> ClaimTransactions { get; set; }
        public virtual ICollection<PayeeBankAccount> PayeeBankAccounts { get; set; }
    }
}
