using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class RepairersViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<Repairer> Repairers { get; set; }
    }
}
