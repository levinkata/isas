using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class LoanViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public Loan Loan { get; set; }
        public SelectList ComponentList { get; set; }
        public string ErrMsg { get; set; }
    }
}
