using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class ClaimTransactionViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public int ClaimNumber { get; set; }
        public ClaimTransaction ClaimTransaction { get; set; }
        public SelectList PayeeList { get; set; }
        public SelectList AccountList { get; set; }
        public SelectList AffectedList { get; set; }
        public SelectList TransactionTypeList { get; set; }
        public string ErrMsg { get; set; }
    }
}
