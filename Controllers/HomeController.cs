using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Isas.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Only Authenticated users can access thier profile
        //[Authorize]
        //public async Task<ActionResult> Profile()
        //{
        //    // Instantiate the ASP.NET Identity system
        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        //    // Get the current logged in User and look up the user in ASP.NET Identity
        //    var currentUser = await manager.FindByIdAsync(manager.GetUserId(User));
        //    //var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());

        //    // Recover the profile information about the logged in user
        //    ViewBag.HomeTown = currentUser.PhoneNumber;
        //    ViewBag.FirstName = currentUser.UserName;

        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        [Authorize]
        public IActionResult Board()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
