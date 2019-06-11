using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class PaymentType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Payement Type")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Receivable> Receivables { get; set; }
        public virtual ICollection<Payable> Payables { get; set; }
    }
}
