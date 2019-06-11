using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class ProductRiskViewModel
    {
        public ProductRisk ProductRisk { get; set; }
        public SelectList RiskList { get; set; }
        public string ErrMsg { get; set; }
    }
}
