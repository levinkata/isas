using System;

namespace Isas.Models.InsurerViewModels
{
    public class FormatTypeViewModel
    {
        public Guid ProductID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public FormatType FormatType { get; set; }
    }
}
