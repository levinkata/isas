using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class PremiumViewModel
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        public Guid PolicyID { get; set; }
        public Receivable Receivable { get; set; }
        public Premium Premium { get; set; }
        public SelectList PremiumTypeList { get; set; }
        public SelectList PaymentTypeList { get; set; }
        public string ErrMsg { get; set; }
    }
}
