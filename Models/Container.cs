using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Container
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please enter the {0}.")]
        [StringLength(50, ErrorMessage = "{0} must be less than {1} characters.")]
        [Display(Name = "Container")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Contact must be less than {1} characters.")]
        [Display(Name = "Contact")]
        public string ContactPerson { get; set; }

        [StringLength(50, ErrorMessage = "{0} must be less than {1} characters.")]
        [Display(Name = "Business")]
        public string Business { get; set; }
        public Guid CountryID { get; set; }

        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
