using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public ProductsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid containerId)
        {
            var products = await _context.Products
                                .Where(p => p.ContainerID == containerId)
                                .AsNoTracking()
                                .ToListAsync();

            ProductsViewModel viewModel = new ProductsViewModel
            {
                ContainerID = containerId,
                Products = products
            };
            return View(viewModel);
        }
    }
}
