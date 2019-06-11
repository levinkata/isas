using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyRisksViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<Risk> Risks { get; set; }
    }
}
