using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Province
    {
        public Guid ID { get; set; }
        public Guid CountryID { get; set; }

        [Required, Display(Name = "Province")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
