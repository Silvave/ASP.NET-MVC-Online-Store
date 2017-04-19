namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resolve_Merge_conflict_Migraiton : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCarts", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCarts", "Product_Id", "dbo.Products");
            DropIndex("dbo.UserCarts", new[] { "Owner_Id" });
            DropIndex("dbo.UserCarts", new[] { "Product_Id" });
            AddColumn("dbo.UserCarts", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.UserCarts", "OwnerId", c => c.String());
            DropColumn("dbo.UserCarts", "Owner_Id");
            DropColumn("dbo.UserCarts", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCarts", "Product_Id", c => c.Int());
            AddColumn("dbo.UserCarts", "Owner_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.UserCarts", "OwnerId");
            DropColumn("dbo.UserCarts", "ProductId");
            CreateIndex("dbo.UserCarts", "Product_Id");
            CreateIndex("dbo.UserCarts", "Owner_Id");
            AddForeignKey("dbo.UserCarts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.UserCarts", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
