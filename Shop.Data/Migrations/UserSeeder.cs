using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Migrations
{
    public static class UserSeeder
    {
        //Creates user without a role (default user).

        public static void CreateOrUpdateUser(UserManager<ApplicationUser> userManager, string userName,string password)
        {
            var user = new ApplicationUser { UserName = userName, Email = userName };
            if (userManager.FindByName(userName) == null)
            {
                var result = userManager.Create(user, password);

            }
            else
            {
                var result = userManager.Update(user);
            }
        }

        // Creates user with a custom (non-admin) role

        public static void CreateOrUpdateUser(RoleManager<IdentityRole> roleManager,string roleName, UserManager<ApplicationUser> userManager, string userName, string password)
        {
            var user = new ApplicationUser { UserName = userName, Email = userName };
            if (userManager.FindByName(userName) == null)
            {
                var result = userManager.Create(user, password);

                if (result.Succeeded)
                {

                    RoleSeeder.CreateRole(roleManager, userManager, roleName);
                    userManager.AddToRole(user.Id, roleName);
                }
            }
            else
            {
                var result = userManager.Update(user);
            }
        }

        //Creates administrator

        public static void CreateOrUpdateAdministrator(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, string userName, string password)
        {
            var user = new ApplicationUser { UserName = userName, Email = userName };
            if (userManager.FindByName(userName) == null)
            {
                var result = userManager.Create(user, password);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }
            }
            else
            {
                var result = userManager.Update(user);
            }
        }
    }
}
