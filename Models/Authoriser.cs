using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Authoriser
    {
        public Guid ID { get; set; }

        [Display(Name =("First Name"))]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = ("Last Name"))]
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = ("Job Title"))]
        [StringLength(50)]
        public string JobTitle { get; set; }
    }
}
