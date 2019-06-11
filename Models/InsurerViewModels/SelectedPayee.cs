using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class SelectedPayee
    {
        public int ClaimNumber { get; set; }
        public Payee Payee { get; set; }
        public SelectList PayeeClassList { get; set; }
    }
}
