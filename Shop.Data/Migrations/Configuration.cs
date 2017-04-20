namespace Shop.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.ShopContext";
            
        }

        protected override void Seed(ShopContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            RoleSeeder.CreateRole(roleManager, userManager, "Administrator");
            RoleSeeder.CreateRole(roleManager, userManager, "Manager");
            RoleSeeder.CreateRole(roleManager, userManager, "Customer");

            UserSeeder.CreateOrUpdateUser(roleManager, "Administrator", userManager, "admin@admin.com",
                "admin", "admin123", "Pesho", "Stamatov", 69);
            UserSeeder.CreateOrUpdateUser(roleManager, "Manager", userManager,"ivan.ivanov@ivan.com", 
                "vankata","ivan123", "Ivan", "Ivanov", 19);
            UserSeeder.CreateOrUpdateUser(roleManager, "Customer", userManager, "peter@pesho.com", 
                "velikiq", "peter123", "Petar", "Petrov", 21);

            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Name = "books", Description = "Books for programming" },
                new Category { Name = "electronicts", Description = "Stuff to write code" },
                new Category { Name = "beverages", Description = "While code - drink" }
                );

           

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
