using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PropertiesViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
}
