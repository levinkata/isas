using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class MotorViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public Motor Motor { get; set; }
        public SelectList CoverageList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorTypeList { get; set; }
        public string ErrMsg { get; set; }
    }
}
