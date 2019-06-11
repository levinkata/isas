using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class MotorSection
    {
        public Guid ID { get; set; }
        public Guid MotorID { get; set; }

        [Display(Name = "Motor Section")]
        [StringLength(50)]
        [Required(ErrorMessage ="Motor Section is required.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Premium { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public virtual Motor Motor { get; set; }
    }
}
