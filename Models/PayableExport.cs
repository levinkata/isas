using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class PayableExport
    {
        public Guid ID { get; set; }

        [Display(Name="Export Name")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Export Date")]
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime ExportDate { get; set; }

        [Display(Name = "File Location")]
        public string FileObject { get; set; }

        [Display(Name = "External Reference")]
        public string ExternalReference { get; set; }

        //public virtual ICollection<Payable> Payables { get; set; }
    }
}
