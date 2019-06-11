using Isas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Affected
    {
        public Guid ID { get; set; }

        [Display(Name = "Affected")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
