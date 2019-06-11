using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ClaimTransactionsViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public int ClaimNumber { get; set; }

        public virtual IEnumerable<ClaimTransaction> ClaimTransactions { get; set; }
    }
}
