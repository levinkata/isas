using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ClientTemp
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int ClientClassID { get; set; }
        public Guid TitleID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationID { get; set; }

        [Display(Name = "Country")]
        public Guid CountryID { get; set; }

        public virtual Title Title { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Country Country { get; set; }
    }
}
