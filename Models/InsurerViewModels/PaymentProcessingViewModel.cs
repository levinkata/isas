using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models.InsurerViewModels
{
    public class PaymentProcessingViewModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }
        public bool AllAccounts { get; set; }
        
        [Display(Name = "Payment Type")]
        public int PaymentTypeID { get; set; }
        public IEnumerable<ChequeTemp> ChequeTemps { get; set; }
        public IEnumerable<ChequeSummaryTemp> ChequeSummaryTemps { get; set; }
        public object[,] BankAccounts { get; set; }
        public SelectList PaymentTypeList { get; set; }
    }
}
