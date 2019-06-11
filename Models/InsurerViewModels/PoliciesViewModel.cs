using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PoliciesViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<Policy> Policies { get; set; }
    }
}
