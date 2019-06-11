using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class BankDirectDebit
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public Guid PolicyID { get; set; }

        [Display(Name = "Branch Code")]
        public string BIC { get; set; }

        [Display(Name = "Account Number")]
        [Required, StringLength(50)]
        public string AccountNumber { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
    }
}
