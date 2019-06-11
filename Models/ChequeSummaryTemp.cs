using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class ChequeSummaryTemp
    {
        public Guid PayeeID { get; set; }  
        public Guid ProductID { get; set; }

        [StringLength(50)]
        public string Payee { get; set; }

        [StringLength(50)]
        public string PostalAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        public int PayeeCount { get; set; }
    }
}
