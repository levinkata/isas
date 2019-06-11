using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ClaimsViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
