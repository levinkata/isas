using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class SelectedPolicyRisk
    {
        public Guid ProductID { get; set; }
        public Guid ContainerID { get; set; }
        public Guid PolicyID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyRiskID { get; set; }
        
        public IEnumerable<AllRisk> allrisks { get; set; }
        public IEnumerable<Commercial> commercials { get; set; }
        public IEnumerable<Content> contents { get; set; }
        public IEnumerable<Loan> loans { get; set; }
        public IEnumerable<Motor> motors { get; set; }
        public IEnumerable<Property> properties { get; set; }
    }
}
