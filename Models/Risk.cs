using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Risk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Risk")]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<ProductRisk> ProductRisks { get; set; }
        public virtual ICollection<RiskClaimClass> RiskClaimClasses{ get; set; }
        public virtual ICollection<RiskIncident> RiskIncidents { get; set; }
        public virtual ICollection<RiskClaimDocument> RiskClaimDocuments { get; set; }        
    }
}
