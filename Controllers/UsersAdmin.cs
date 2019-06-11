using Isas.Data;
using Isas.Models;
using Isas.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    // [Authorize(Roles = "Administrator")] -- Commented by Levi Nkata 26/04/2019
    public class UsersAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;
        
        public UsersAdminController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        
        //
        // GET: /Users/Details/5
        public async Task<IActionResult> Details(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(Id);
            return View(user);
        }

        //
        // GET: /Users/Create
        public async Task<IActionResult> Create()
        {
            RegisterViewModel viewModel = new RegisterViewModel
            {
                Id = "d72gf89c-6b05-4838-873d-8968af3a0a61",
                RoleList = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name")
            };
            return View(viewModel);
        }

        //
        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = viewModel.UserName,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email
                };
                var adduserresult = await _userManager.CreateAsync(user, viewModel.Password);
                string selectedroleId = viewModel.RoleId;

                //  Add User to Role
                if (adduserresult.Succeeded)
                {
                    if (!String.IsNullOrEmpty(selectedroleId))
                    {
                        //  Find Selected Role
                        var selectedrole = await _roleManager.FindByIdAsync(selectedroleId);
                        var result = await _userManager.AddToRoleAsync(user, selectedrole.Name);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            viewModel.RoleList = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", viewModel.RoleId);
                            return View(viewModel);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adduserresult.Errors.First().ToString());
                    viewModel.RoleList = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", viewModel.RoleId);
                    return View(viewModel);
                }
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.RoleList = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", viewModel.RoleId);
                return View(viewModel);
            }
        }

        //
        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var firstRole = userRoles.FirstOrDefault();

            IdentityRole userRole = await _roleManager.FindByNameAsync(firstRole);
            var currentroleId = userRole.Id;

            RegisterViewModel viewModel = new RegisterViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.PasswordHash,
                ConfirmPassword = user.PasswordHash,
                RoleId = currentroleId,
                RoleList = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", currentroleId)
            };
            return View(viewModel);
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
                var user = await _userManager.FindByIdAsync(viewModel.Id);
                user.UserName = viewModel.UserName;
                user.PhoneNumber = viewModel.PhoneNumber;
                user.Email = viewModel.Email;

                //Update the user details
                await _userManager.UpdateAsync(user);

                //If user has existing Role then remove the user from the role
                // This also accounts for the case when the Admin selected Empty from the drop-down and
                // this means that all roles for the user must be removed
                var rolesForUser = await _userManager.GetRolesAsync(user);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, item);
                    }
                }

                if (!String.IsNullOrEmpty(viewModel.RoleId))
                {
                    //Find Role
                    var role = await _roleManager.FindByIdAsync(viewModel.RoleId);

                    //Add user to new role
                    var result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
        //public async Task<ActionResult> Delete(string Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var user = await _userManager.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //
        // POST: /Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string Id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        var user = await _userManager.FindByIdAsync(Id);
        //        var result = await _userManager.DeleteAsync(user);
        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", result.Errors.First().ToString());
        //            return View();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}