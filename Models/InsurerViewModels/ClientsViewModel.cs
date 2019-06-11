using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ClientsViewModel
    {
        public int PayeeClassID { get; set; }
        public IEnumerable<object> Clients { get; set; }
    }
}
