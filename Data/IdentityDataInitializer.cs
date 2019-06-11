using Isas.Models;
using Microsoft.AspNetCore.Identity;

namespace Isas.Data
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            SeedRoles(_roleManager);
            SeedUsers(_userManager);
        }

        //  Create Startup Users
        public static void SeedUsers(UserManager<ApplicationUser> _userManager)
        {
            if (_userManager.FindByNameAsync("levi.nkata").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "levi.nkata",
                    Email = "levi.nkata@outlook.com",
                    PhoneNumber = "72107147"
                };

                string userPWD = "Susan@0570";
                IdentityResult result = _userManager.CreateAsync(user, userPWD).Result;

                if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (_userManager.FindByNameAsync("naledi.nkata").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "naledi.nkata",
                    Email = "naledi.nkata@outlook.com",
                    PhoneNumber = "72107148"
                };

                string userPWD = "Susan@0570";
                IdentityResult result = _userManager.CreateAsync(user, userPWD).Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }
        }

        //  Create Startup Roles
        public static void SeedRoles(RoleManager<IdentityRole> _roleManager)
        {
            if(!_roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "NormalUser"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Administrator"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
