using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClientType
    {
        public Guid ID { get; set; }

        [Display(Name = "Client Type")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public bool IsFirm { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
