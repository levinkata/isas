using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class ReceivableViewModel
    {
        public Guid PolicyID { get; set; }
        public Guid ClaimID { get; set; }
        public Receivable Receivable { get; set; }

        public SelectList PaymentTypeList { get; set; }
    }
}
