using Isas.CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Content
    {
        public Guid ID { get; set; }
        public Guid PolicyID { get; set; }

        [Display(Name = "Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
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

        [Display(Name = "Wall")]
        public Guid WallTypeID { get; set; }

        [Display(Name = "Roof")]
        public Guid RoofTypeID { get; set; }

        [Display(Name = "Residence")]
        public Guid ResidenceTypeID { get; set; }

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

        public virtual Policy Policy { get; set; }
        public virtual WallType WallType { get; set; }
        public virtual RoofType RoofType { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }
    }
}
