using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class MotorThirdParty
    {
        public Guid ID { get; set; }
        public int ClaimNumber { get; set; }

        [Display(Name = "Registration Number")]
        [Required, StringLength(50)]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Type")]
        public Guid MotorTypeID { get; set; }

        [Display(Name = "Make")]
        public Guid MotorMakeID { get; set; }

        [Display(Name = "Model")]
        public Guid MotorModelID { get; set; }

        [Required, Display(Name = "Year")]
        public int ManufacturerYear { get; set; }

        [Display(Name = "Engine Number")]
        [Required, StringLength(50)]
        public string EngineNumber { get; set; }

        [Display(Name = "Chassis Number")]
        [Required, StringLength(50)]
        public string ChassisNumber { get; set; }

        public virtual Claim Claim { get; set; }
        //public virtual MotorType MotorType { get; set; }
        //public virtual MotorMake MotorMake { get; set; }
    }
}
