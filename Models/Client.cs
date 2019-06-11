using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public enum Gender
    {
        Female, Male, Unspecified
    }

    public class Client
    {
        public Guid ID { get; set; }

        [Display(Name = "Client Type")]
        public Guid ClientTypeID { get; set; }

        [Display(Name = "Title")]
        public Guid TitleID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is mandatory")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(NullDisplayText="Unspecified")]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [StringLength(50)]
        [Required (ErrorMessage = "ID Number is mandatory")]
        [Display(Name = "ID Number")]
        [Remote(action: "VerifyIDNumber", controller: "Clients")]
        public string IDNumber { get; set; }

        [Display(Name = "Phone")]
        [Required, StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required, DataType(DataType.EmailAddress), StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationID { get; set; }

        [Display(Name = "Country")]
        public Guid CountryID { get; set; }

        public int PayeeClassID { get; set; }

        [Display(Name = "Payee")]
        public bool Payable { get; set; }
        public int BulkHandle { get; set; }

        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Title Title { get; set; }
        public virtual ClientType ClientType { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Country Country { get; set; }
    }
}
