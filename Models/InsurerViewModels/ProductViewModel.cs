using Isas.Data;
using System;

namespace Isas.Models.InsurerViewModels
{
    public class ProductViewModel
    {
        public Guid ContainerID { get; set; }
        public string ContainerName { get; set; }
        public Product Product { get; set; }
    }
}
