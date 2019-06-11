using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class FormatTypesViewModel
    {
        public Guid ProductID { get; set; }
        public UploadFileTypes UploadFileType { get; set; }
        public IEnumerable<FormatType> FormatTypes { get; set; }
    }
}
