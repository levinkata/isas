using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class RiskClaimDocumentViewModel
    {
        public string RiskID { get; set; }
        public string[] Assigned { get; set; }
        public string[] Available { get; set; }
        public SelectList Risks { get; set; }
        public MultiSelectList ClaimDocumentList { get; set; }
        public MultiSelectList RiskClaimDocumentList { get; set; }
    }
}
