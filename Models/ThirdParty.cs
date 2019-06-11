using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ThirdParty
    {
        public Guid ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Display(Name = "ID Number")]
        [StringLength(50)]
        [Required(ErrorMessage = "ID Number is required.")]
        public string IDNumber { get; set; }

        public int PayeeClassID { get; set; }
        public bool Payable { get; set; }

        public ICollection<ClaimRecovery> ClaimRecoveries { get; set; }
        public ICollection<ClaimThirdParty> ClaimThirdParties { get; set; }
    }
}
