using Isas.Data;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class BankBranchViewModel
    {
        public Guid BankID { get; set; }
        public string BankName { get; set; }
        public BankBranch BankBranch { get; set; }
    }
}
