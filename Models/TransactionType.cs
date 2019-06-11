using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class TransactionType
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Transaction")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ClaimTransaction> ClaimTransactions { get; set; }
    }
}
