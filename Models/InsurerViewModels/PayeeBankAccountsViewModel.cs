using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PayeeBankAccountsViewModel
    {
        public Guid PayeeID { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}
