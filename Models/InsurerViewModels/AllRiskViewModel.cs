using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class AllRiskViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public AllRisk AllRisk { get; set; }
        public SelectList ComponentList { get; set; }
        public string ErrMsg { get; set; }
    }
}
