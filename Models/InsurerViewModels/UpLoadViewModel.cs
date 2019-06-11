using Isas.Data;
using Microsoft.AspNetCore.Http;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class UpLoadViewModel
    {
        public Guid ProductID { get; set; }
        public IFormFile UpLoadFile { get; set; }
        public Guid LoadFormatID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public string Delimiter { get; set; }
        public string TableName { get; set; }
        public int StartRow { get; set; }
    }
}
