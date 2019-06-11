using Isas.Data;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class LossAdjustersViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<LossAdjuster> LossAdjusters { get; set; }
    }
}
