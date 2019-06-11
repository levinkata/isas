using Isas.CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class AllRiskHistory
    {
        public Guid ID { get; set; }
        public Guid PolicyID { get; set; }
        
        [Display(Name = "Component")]
        public Guid ComponentID { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string Description { get; set; }

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

        [Display(Name = "Comment")]
        [StringLength(50)]
        public string Comment { get; set; }

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
        public virtual Component Component { get; set; }
    }
}
