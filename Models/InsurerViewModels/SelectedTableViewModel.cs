using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class SelectedTableViewModel
    {
        public Guid ProductID { get; set; }
        public Guid LoadFormatID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public string TableName { get; set; }
        public SelectList TableList { get; set; }
    }
}
