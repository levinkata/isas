using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Cheque
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        
        [Display(Name = "Cheque Number")]
        [StringLength(50)]
        public string ChequeNumber { get; set; }

        //[Display(Name = "Date")]
        public DateTime ChequeDate { get; set; }

        [Display(Name = "Amount")]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Batch Number")]
        [StringLength(50)]
        public string BatchNumber { get; set; }

        [Display(Name = "Void")]
        public bool Void { get; set; }

        [Display(Name = "Void Reason")]
        [StringLength(50)]
        public string VoidReason { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(50)]
        public string Remarks { get; set; }

        [Display(Name = "Export")]
        public Guid? ChequeExportID { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
