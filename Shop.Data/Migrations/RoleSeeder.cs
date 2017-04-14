namespace Shop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public static class RoleSeeder
    {
        public static void CreateRole(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }
    }
}
