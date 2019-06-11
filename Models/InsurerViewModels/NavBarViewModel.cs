using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class NavBarViewModel
    {
        public List<NavBarItemViewModel> NavBarItems { get; set; }

        public NavBarViewModel(List<NavBarItemViewModel> navBarItems)
        {
            NavBarItems = navBarItems;
        }
    }
}
