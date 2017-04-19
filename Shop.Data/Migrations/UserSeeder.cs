namespace Shop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public static class UserSeeder
    {
        //Creates user without a role (default user).
        //public static void CreateOrUpdateUser(UserManager<ApplicationUser> userManager, string userName,string password)
        //{
        //    var user = new ApplicationUser { UserName = userName, Email = userName };
        //    if (userManager.FindByName(userName) == null)
        //    {
        //        var result = userManager.Create(user, password);

        //    }
        //    else
        //    {
        //        var result = userManager.Update(user);
        //    }
        //}

        // Creates user with a custom (non-admin) role
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
