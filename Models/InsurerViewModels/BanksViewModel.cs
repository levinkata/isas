using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class BanksViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
    }
}
