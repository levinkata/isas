using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class AttorneysViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<Attorney> Attorneys { get; set; }
    }
}
