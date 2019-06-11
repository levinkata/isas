using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class LoadFormatViewModel
    {
        public Guid ProductID { get; set; }
        public LoadFormat LoadFormat { get; set; }
        public SelectList FileTypeList { get; set; }
    }
}
