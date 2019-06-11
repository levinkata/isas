using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class MotorType
    {
        public Guid ID { get; set; }

        [Display(Name="Motor Type")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Motor> Motors { get; set; }
        //public ICollection<MotorThirdParty> MotorsThirdParty { get; set; }
    }
}
