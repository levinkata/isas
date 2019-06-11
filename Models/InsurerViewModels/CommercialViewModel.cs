using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class CommercialViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public Commercial Commercial { get; set; }
        public SelectList ComponentList { get; set; }
        public string ErrMsg { get; set; }
    }
}
