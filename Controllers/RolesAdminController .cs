using Isas.Data;
using Isas.Models;
using Isas.Models.ManageViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    // [Authorize(Roles = "Administrator")] -- Commented by Levi Nkata 26/04/2019
    public class RolesAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RolesAdminController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        //
        // GET: /Roles/Details/5
        public async Task<ActionResult> Details(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var role = await _roleManager.FindByIdAsync(Id);
            return View(role);
        }

        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(viewModel.Name);
                var roleresult = await _roleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Roles/Edit/Admin
        public async Task<ActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return NotFound();
            }
            RoleViewModel viewModel = new RoleViewModel
            {
                ID = role.Id,
                Name = role.Name
            };
            
            return View(viewModel);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(viewModel.Name);
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        //
        // GET: /Roles/Delete/5
        public async Task<ActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string Id)
        {
            if (ModelState.IsValid)
            {
                if (Id == null)
                {
                    return BadRequest();
                }
                var role = await _roleManager.FindByIdAsync(Id);
                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
