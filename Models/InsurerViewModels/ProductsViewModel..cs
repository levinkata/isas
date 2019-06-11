using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ProductsViewModel
    {
        public Guid ContainerID { get; set; }
        public string ContainerName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
