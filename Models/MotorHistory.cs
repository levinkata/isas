using Isas.CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class MotorHistory
    {
        public Guid ID { get; set; }
        public Guid PolicyID { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "Registration Number is required.")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Type")]
        public Guid MotorTypeID { get; set; }

        [Display(Name = "Make")]
        public Guid MotorMakeID { get; set; }

        [Display(Name = "Model")]
        public Guid MotorModelID { get; set; }

        [Display(Name = "Year")]
        public int ManufacturerYear { get; set; }

        [Display(Name = "Engine Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "Engine Number is required.")]
        public string EngineNumber { get; set; }

        [Display(Name = "Chassis Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "Chassis Number is required.")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Premium { get; set; }

        [Required, Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DateTimeCompare("EndDate", ValueComparison.IsLessThan,
            ErrorMessage = "Start Date must be earlier than End Date.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        [DateTimeCompare("StartDate", ValueComparison.IsGreaterThan,
            ErrorMessage = "End Date must be later than Start Date.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Coverage")]
        public Guid CoverageID { get; set; }

        [Display(Name = "Driver")]
        public Guid DriverTypeID { get; set; }

        [Display(Name = "Private")]
        public bool PrivateUse { get; set; }

        [Display(Name = "Business")]
        public bool BusinessUse { get; set; }

        [Display(Name = "CFG")]
        [Range(1, 99)]
        public int CFG { get; set; }

        [Display(Name = "Immobiliser")]
        public bool Immobiliser { get; set; }

        [Display(Name = "Alarm")]
        public bool Alarm { get; set; }

        [Display(Name = "Grey Import")]
        public bool GreyImport { get; set; }

        [Display(Name = "Territorial Limit")]
        [StringLength(250)]
        public string TerritorialLimit { get; set; }

        [Display(Name = "Policy Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Insurer Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal InsurerFee { get; set; }

        [Display(Name = "Commission")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Commission { get; set; }

        [Display(Name = "Admin Fee")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal AdminFee { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
