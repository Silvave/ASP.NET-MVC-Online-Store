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
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentLike> CommentLikes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductLike> ProductLikes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductLike>()
                .HasRequired(l => l.Product)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.ProductId);

            modelBuilder.Entity<CommentLike>()
                .HasRequired(l => l.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(l => l.CommentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}