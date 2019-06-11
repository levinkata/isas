using Isas.Data;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Components
{
    public class MotorsViewComponent : ViewComponent
    {
        private readonly InsurerDbContext _context;

        public MotorsViewComponent(InsurerDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid ProductId, Guid clientId, Guid policyId)
        {
            var motors = await _context.Motors
                                    .Include(m => m.Coverage)
                                    .Include(m => m.DriverType)
                                    .Include(m => m.MotorMake)
                                    .Include(m => m.MotorType)
                                    .AsNoTracking()
                                    .Where(a => a.PolicyID == policyId)
                                    .OrderBy(c => c.RegistrationNumber).ToListAsync();

            MotorsViewModel viewModel = new MotorsViewModel
            {
                ProductID = ProductId,
                ClientID = clientId,
                PolicyID = policyId,
                Motors = motors
            };
            return View(viewModel);
        }
    }
}
