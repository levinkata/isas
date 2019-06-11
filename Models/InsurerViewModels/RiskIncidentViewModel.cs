using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class RiskIncidentViewModel
    {
        public string RiskID { get; set; }
        public string [] Assigned { get; set; }
        public string [] Available { get; set; }
        public SelectList Risks { get; set; }
        public MultiSelectList IncidentList { get; set; }
        public MultiSelectList RiskIncidentList { get; set; }
    }
}
