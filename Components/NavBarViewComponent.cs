using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navBarItems = new List<NavBarItemViewModel>();
            await Task.Run(() =>
            {
                navBarItems.Add(new NavBarItemViewModel("Action 1", "#"));
                navBarItems.Add(new NavBarItemViewModel("Action 2", "#"));
                navBarItems.Add(new NavBarItemViewModel("Action 3", "#"));
            });

            var viewModel = new NavBarViewModel(navBarItems);

            return View(viewModel);
        }
    }
}
