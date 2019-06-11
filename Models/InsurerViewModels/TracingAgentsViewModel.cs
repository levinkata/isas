using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class TracingAgentsViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<TracingAgent> TracingAgents { get; set; }
    }
}
