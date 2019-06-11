using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyBankAccountViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public Guid BankID { get; set; }
        public BankAccount BankAccount { get; set; }
        public SelectList BankList { get; set; }
        public SelectList BankBranchList { get; set; }
    }
}
