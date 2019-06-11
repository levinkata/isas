using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ThirdPartiesViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<ThirdParty> ThirdParties { get; set; }
    }
}
