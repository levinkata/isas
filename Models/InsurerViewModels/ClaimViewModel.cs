using System;
using System.Collections.Generic;
using System.Linq;
using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class ClaimViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }

        public Claim Claim { get; set; }

        public SelectList ClaimClassList { get; set; }
        public SelectList ClaimStatusList { get; set; }
        public SelectList IncidentList { get; set; }
        public SelectList RegionList { get; set; }
        public SelectList ProvinceList { get; set; }
        public SelectList CountryList { get; set; }
    }
}
