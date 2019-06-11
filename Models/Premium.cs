using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Premium
    {
        public Guid ID { get; set; }
        public Guid PolicyID { get; set; }
        public int RiskID { get; set; }
        public Guid RiskItemID { get; set; }

        [Display(Name = "Premium Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime PremiumDate { get; set; }
        
        [Display(Name = "Type")]
        public Guid PremiumTypeID { get; set; }

        [Display(Name = "Premium")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Policy Fee")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Commission")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Commission { get; set; }

        [Display(Name = "Admin Fee")]
        [DisplayFormat(DataFormatString = "{0:n2}",
            ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal AdminFee { get; set; }

        [Display(Name = "Received")]
        public Guid ReceivableID { get; set; }
        public int BulkHandle { get; set; }
        
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual PremiumType PremiumType { get; set; }
        public virtual Receivable Receivable { get; set; }
    }
}
