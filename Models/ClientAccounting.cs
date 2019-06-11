using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class ClientAccounting
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public Guid InsurerID { get; set; }
        public Guid PolicyID { get; set; }
        public Guid PremiumID { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Amount")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Adjustment")]
        public Guid Adjustment { get; set; }

        [Display(Name = "Refund")]
        public Guid Refund { get; set; }
        public string AccountStatus { get; set; }
    }
}
