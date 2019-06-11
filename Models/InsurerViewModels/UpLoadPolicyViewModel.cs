using Isas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models.InsurerViewModels
{
    public class UpLoadPolicyViewModel
    {
        public IFormFile UpLoadFile { get; set; }
        public Guid LoadFormatID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public string Delimiter { get; set; }
        public string TableName { get; set; }
        public int StartRow { get; set; }
        public Guid InsurerID { get; set; }
        public Guid PolicyFrequencyID { get; set; }
        public Guid PolicyStatusID { get; set; }
        public DateTime? StatusDate { get; set; }

        [Display(Name = "Premium Due Date")]
        [DataType(DataType.Date)]
        public DateTime? PremiumDueDate { get; set; }
        public int PolicyVersion { get; set; }

        [Display(Name = "Inception Date")]
        [DataType(DataType.Date)]
        public DateTime? InceptionDate { get; set; }
        public bool Renewable { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList PolicyFrequencyList { get; set; }
        public SelectList PolicyStatusList { get; set; }
        public SelectList IncomeClassList { get; set; }
    }
}
