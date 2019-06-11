using System;

namespace Isas.Models
{
    public class PolicyBankAccount
    {
        public Guid PolicyID { get; set; }
        public Guid BankAccountID { get; set; }
        
        public virtual Policy Policy { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}
