using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyViewModel
    {
        public Policy Policy { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList PolicyFrequencyList { get; set; }
        public SelectList PolicyStatusList { get; set; }
        public SelectList IncomeClassList { get; set; }
        public string ErrMsg { get; set; }
    }
}