using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyTempsViewModel
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public IEnumerable<PolicyTemp> PolicyTemps { get; set; }
    }
}
