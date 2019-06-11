using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyRiskViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public int RiskID { get; set; }
        public AllRisk AllRisk { get; set; }
        public Commercial Commercial { get; set; }
        public Content Content { get; set; }
        public Loan Loan { get; set; }
        public Motor Motor { get; set; }
        public Property Property { get; set; }

        //public Workman Workman { get; set; }

        public SelectList ComponentList { get; set; }
        public SelectList CoverTypeList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorTypeList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }
    }
}
