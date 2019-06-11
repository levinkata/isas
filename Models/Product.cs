using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Product
    {
        public Guid ID { get; set; }

        public Guid ContainerID { get; set; }

        [Display(Name = "Product")]
        [StringLength(50)]
        [Required(ErrorMessage ="Product name is required.")]
        public string Name { get; set; }

        [Display(Name = "Renewal Period")]
        [Range(1, 9)]
        public int RenewalPeriod { get; set; }

        public virtual ICollection<ProductRisk> ProductRisks { get; set; }
        public virtual Container Container { get; set; }
    }
}
