using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class AccountChart
    {
        public Guid ID { get; set; }

        [Display(Name = "Account Code")]
        [StringLength(50)]
        public string AccountCode { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Income/Expense")]
        [StringLength(50)]
        public int IncomeOrExpense { get; set; }

        public ICollection<ClaimTransaction> ClaimTransactions { get; set; }
        public ICollection<PremiumRefund> PremiumRefunds { get; set; }
    }
}
