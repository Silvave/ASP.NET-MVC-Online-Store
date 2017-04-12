namespace Shop.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext()
            : base("ShopContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}