using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isas.Models.ManageViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string RoleId { get; set; }
        public SelectList RoleList { get; set; }
    }
}
