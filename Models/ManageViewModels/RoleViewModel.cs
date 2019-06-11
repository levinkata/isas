using System.ComponentModel.DataAnnotations;

namespace Isas.Models.ManageViewModels
{
    public class RoleViewModel
    {
        public string ID { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
