namespace Shop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public static class UserSeeder
    {
        // Creates user with a custom role
        public static void CreateOrUpdateUser(RoleManager<IdentityRole> roleManager,string roleName, UserManager<ApplicationUser> userManager, string email, string userName, string password, string firstname, string lastname, int age)
        {
            var user = new ApplicationUser { UserName = userName, Email = email,
                FirstName = firstname, LastName = lastname, Age = age };
            if (userManager.FindByName(userName) == null)
            {
                var result = userManager.Create(user, password);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, roleName);
                }
            }
            else
            {
                var result = userManager.Update(user);
            }
        }
    }
}
