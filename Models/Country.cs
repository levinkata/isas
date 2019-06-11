using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Country
    {
        public Guid ID { get; set; }

        [Required, Display(Name = "Country")]        
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "ISO Code")]
        [StringLength(3)]
        public string ISOCode { get; set; }

        [Display(Name = "Currency")]
        [StringLength(3)]
        public string ISOCurrency { get; set; }
        
        [Display(Name = "Dialing Code")]
        public int? DialingCode { get; set; }

        [Display(Name = "Tax")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Tax { get; set; }
        
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
