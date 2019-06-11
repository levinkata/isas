using Isas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class UpLoadLoanViewModel
    {
        public IFormFile UpLoadFile { get; set; }
        public Guid LoadFormatID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public string Delimiter { get; set; }
        public string TableName { get; set; }
        public int StartRow { get; set; }
        public Guid ComponentID { get; set; }

        public SelectList ComponentList { get; set; }
    }
}
