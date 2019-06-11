using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class PayeeClass
    {
        //  8 potential Payee Classes: Attorney, Bank, Client, 
        //  Insurer, LossAdjuster, Repairer, ThirdParty, TracingAgent

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required, Range(1, 99)]
        public int ID { get; set; }

        [Display(Name = "Payee Class")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Payee> Payees { get; set; }
    }
}
