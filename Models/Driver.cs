using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Driver
    {
        public Guid ID { get; set; }

        [Display(Name = "Title")]
        public Guid TitleID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Phone")]
        [Required, StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required, DataType(DataType.EmailAddress), StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "ID Number is mandatory")]
        [Display(Name = "ID Number")]
        [Remote(action: "VerifyIDNumber", controller: "Clients")]   //  Create this in DriversController
        public string IDNumber { get; set; }

        [Display(Name = "License Number")]
        [Required, StringLength(50)]
        public string LicenseNumber { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "License Issue Date")]
        public DateTime LicenseIssueDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "License Expiry Date")]
        public DateTime LicenseExpiryDate { get; set; }

        public virtual Title Title { get; set; }

        public virtual ICollection<MotorDriver> MotorDrivers { get; set; }
        public virtual ICollection<ClaimDriver> ClaimDrivers { get; set; }
    }
}
