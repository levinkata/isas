using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Incident
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Incident")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<RiskIncident> RiskIncidents { get; set; }
    }
}
