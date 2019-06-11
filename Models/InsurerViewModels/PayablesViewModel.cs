using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models.InsurerViewModels
{
    public class PayablesViewModel
    {
        public Guid ProductID { get; set;}
        public IEnumerable<Payable> Payables { get; set; }

        [Display(Name = "Payment Type")]
        public int PaymentTypeID { get; set; }
        public SelectList PaymentTypeList { get; set; }
    }
}
