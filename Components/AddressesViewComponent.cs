using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class AddressesViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public AddressesViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id, string containername)
        {
            var addresses = await _context.Addresses
                                .Where(a => (a.AddressAssignments.Any(s => s.AddressID == a.ID && s.ItemID == id)))
                                .AsNoTracking()
                                .ToListAsync();

            AddressesViewModel viewModel = new AddressesViewModel
            {
                ItemID = id,
                ContainerName = containername,
                Addresses = addresses
            };
            return View(viewModel);
        }
    }
}
