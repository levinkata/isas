using Isas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models.InsurerViewModels
{
    public class UpLoadPremiumViewModel
    {
        public IFormFile UpLoadFile { get; set; }
        public Guid LoadFormatID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public string Delimiter { get; set; }
        public string TableName { get; set; }
        public int StartRow { get; set; }

        public string Reference { get; set; }

        [Display(Name = "Receivable Date")]
        [Required, DataType(DataType.Date)]
        public DateTime ReceivableDate { get; set; }

        [Display(Name = "Payment Type")]
        public Guid PaymentTypeID { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Payment Amount")]
        public decimal PaymentAmount { get; set; }

        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }

        [Display(Name = "Premium Date")]
        [DataType(DataType.Date)]
        public DateTime? PremiumDate { get; set; }

        [Display(Name = "Type")]
        public Guid PremiumTypeID { get; set; }

        [Display(Name = "Received")]
        public SelectList PaymentTypeList { get; set; }
        public SelectList PremiumTypeList { get; set; }
    }
}
