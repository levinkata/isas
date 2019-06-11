using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PayableViewModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Payable Payable { get; set; }
        public IEnumerable<ClaimTransaction> ClaimTransactions { get; set; }
    }
}
