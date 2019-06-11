using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Occupation
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Occupation")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
