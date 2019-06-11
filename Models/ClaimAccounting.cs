using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Data
{
    public class ClaimAccounting
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public Guid InsurerID { get; set; }
        public Guid PolicyID { get; set; }
        public int ClaimNumber { get; set; }
        public Guid ClaimClassID { get; set; }

        public DateTime InvoiceDate { get; set; }

        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }
        public Guid PayeeID { get; set; }
        public Guid AffectedID { get; set; }
    }
}
