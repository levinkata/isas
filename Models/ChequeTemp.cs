using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ChequeTemp
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public int ClaimNumber { get; set; }
        public Guid PayeeID { get; set; }

        [StringLength(50)]
        public string Payee { get; set; }

        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [StringLength(50)]
        public string AccountCode { get; set; }

        [StringLength(50)]
        public string Affected { get; set; }

        public bool Authorised { get; set; }

        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        [StringLength(50)]
        public string Insurer { get; set; }

        [StringLength(50)]
        public string Product { get; set; }
    }
}
