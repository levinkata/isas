using Isas.Data;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class AddressViewModel
    {
        public Guid ItemID { get; set; }
        public string ControllerName { get; set; }
        public Address Address { get; set; }
    }
}
