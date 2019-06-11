using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class MotorModel
    {
        public Guid ID { get; set; }

        [Display(Name = "Make")]
        public Guid MotorMakeID { get; set; }

        [Required, Display(Name = "Model")]
        [StringLength(50)]
        public string Name { get; set; }

        public MotorMake MotorMake { get; set; }
    }
}
