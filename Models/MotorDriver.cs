using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class MotorDriver
    {
        public Guid MotorID { get; set; }
        public Guid DriverID { get; set; }

        [Display(Name = "Is Primary Driver?")]
        public bool IsPrimaryDriver { get; set; }

        public virtual Motor Motor { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
