using Isas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.InsurerViewModels
{
    public class ClientViewModel
    {
        public Client Client { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList TitleList { get; set; }
        public SelectList ClientTypeList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList GenderList { get; set; }
        public string ErrMsg { get; set; }
    }
}
