using System;

namespace Isas.Models
{
    public class ProductClient
    {
        public Guid ProductID { get; set; }
        public Guid ClientID { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Client Client { get; set; }
    }
}
