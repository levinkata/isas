using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class AddressesViewModel
    {
        public Guid ItemID { get; set; }
        public string ContainerName { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
