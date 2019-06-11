using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class LoadFormatsViewModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<LoadFormat> LoadFormats { get; set; }
    }
}
