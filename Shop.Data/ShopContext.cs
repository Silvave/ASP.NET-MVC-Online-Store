namespace Shop.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}