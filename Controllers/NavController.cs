using Isas.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Isas.Controllers
{
    public class NavController : Controller
    {
        private readonly InsurerDbContext _context;

        public NavController(InsurerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu1()
        {
            IEnumerable<string> risks = _context.Risks
                                            .Select(n => n.Name)
                                            .Distinct()
                                            .OrderBy(r => r).ToList();
            return PartialView(risks);
        }
    }
}