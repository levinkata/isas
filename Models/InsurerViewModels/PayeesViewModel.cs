using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PayeesViewModel
    {
        public IEnumerable<Attorney> Attorneys { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Insurer> Insurers { get; set; }
        public IEnumerable<LossAdjuster> LossAdjusters  { get; set; }
        public IEnumerable<Repairer> Repairers { get; set; }
        public IEnumerable<ThirdParty> ThirdParties { get; set; }
        public IEnumerable<TracingAgent> TracingAgents { get; set; }
    }
}
