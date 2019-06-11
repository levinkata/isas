using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class PayeeBankAccountViewModel
    {
        public Guid PayeeID { get; set; }
        public Guid BankID { get; set; }
        public BankAccount BankAccount { get; set; }
        public SelectList BankList { get; set; }
        public SelectList BankBranchList { get; set; }
    }
}
