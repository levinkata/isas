using System;

namespace Isas.Models
{
    public class RiskIncident
    {
        public int RiskID { get; set; }
        public Guid IncidentID { get; set; }

        public virtual Risk Risk { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
