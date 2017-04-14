namespace Shop.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.ShopContext";
        }

        protected override void Seed(ShopContext context)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //RoleSeeder.CreateRole(roleManager, userManager, "Administrators");
            //UserSeeder.CreateOrUpdateAdministrator(roleManager, userManager, "admin@admin.com", "admin123");
            //UserSeeder.CreateOrUpdateUser(userManager, "ivan.ivanov@ivan.com","ivan123");
            //UserSeeder.CreateOrUpdateUser(userManager, "peter@pesho.com", "peter123");
          

            //context.Addresses.AddOrUpdate(
            //    a => a.StreetName,
            //    new Address { StreetName = "Pirin 16 left rock" },
            //    new Address { StreetName = "Musala 1337 second floor" },
            //    new Address { StreetName = "Balkan 123" });

            //var cheese = new Category { Name = "Cheese" };

            //var products = new List<Product>()
            //{
            //    new Product { ShortDescription = "Mozzarella", Price = 7.50m },
            //    new Product { ShortDescription = "Brie", Price = 12.20m },
            //    new Product { ShortDescription = "Brie De Meaux", Price = 12.20m }
            //};

            //products.ForEach(p => cheese.Products.Add(p));

            //context.Categories.AddOrUpdate(c => c.Name, cheese);
        }
    }
}
