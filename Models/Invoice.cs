using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isas.Models
{
    public class Invoice
    {
        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }        //  -2,147,483,648 to 2,147,483,647
        public Guid PolicyID { get; set; }

        [Display(Name = "Invoice Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime InvoiceDate { get; set; }
        public int Status { get; set; }                 //  Paid=1, Unpaid=0, etc

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
