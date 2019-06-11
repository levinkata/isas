using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class MotorMake
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Make")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<MotorModel> MotorModels { get; set; }
        public virtual ICollection<Motor> Motors { get; set; }
        //public virtual ICollection<MotorThirdParty> MotorsThirdParty { get; set; }
    }
}
