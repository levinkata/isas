using System;

namespace Isas.Models
{
    public class PayeeBankAccount
    {
        public Guid PayeeID { get; set; }
        public Guid BankAccountID { get; set; }

        public virtual Payee Payee { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}
