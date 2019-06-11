using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class ContainerViewModel
    {
        public Container Container { get; set; }
        public SelectList CountryList { get; set; }
    }
}
