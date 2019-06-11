using System;

namespace Isas.Models
{
    public class AddressAssignment
    {
        public Guid ItemID { get; set; }
        public Guid AddressID { get; set; }
        
        public virtual Address Address { get; set; }
    }
}
