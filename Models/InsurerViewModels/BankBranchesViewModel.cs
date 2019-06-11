using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class BankBranchesViewModel
    {
        public Guid BankID { get; set; }
        public string BankName { get; set; }
        public IEnumerable<BankBranch> BankBranches { get; set; }
    }
}
