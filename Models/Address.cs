using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Address
    {
        public Guid ID { get; set; }

        [Display(Name ="Physical Address")]
        [StringLength(100)]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        [StringLength(50)]
        public string PostalAddress { get; set; }

        [Display(Name = "Country")]
        public Guid CountryID { get; set; }

        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Province")]
        public Guid ProvinceID { get; set; }
        
        public virtual Country Country { get; set; }

        public virtual ICollection<AddressAssignment> AddressAssignments { get; set; }
    }
}
