using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class InvoiceItem
    {
        public Guid ID { get; set; }
        public int InvoiceID { get; set; }
        public int RiskID { get; set; }
        public Guid RiskItemID { get; set; }

        // [Column(TypeName = "decimal(15,2)")]
        public decimal Premium { get; set; }

        // [Column(TypeName = "decimal(15,2)")]
        public decimal TaxAmount { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
