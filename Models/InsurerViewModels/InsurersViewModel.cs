using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class InsurersViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<Insurer> Insurers { get; set; }
    }
}
