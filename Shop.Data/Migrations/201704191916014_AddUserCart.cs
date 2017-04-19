namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCart : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.UserCarts", c => new
            {
                Id = c.Int(nullable:false, identity:true)
            });
            AddColumn("dbo.UserCarts", "Owner_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserCarts", "Product_Id", c => c.Int());
            CreateIndex("dbo.UserCarts", "Owner_Id");
            CreateIndex("dbo.UserCarts", "Product_Id");
            AddForeignKey("dbo.UserCarts", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserCarts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.UserCarts", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserCarts", new[] { "Product_Id" });
            DropIndex("dbo.UserCarts", new[] { "Owner_Id" });
            DropColumn("dbo.UserCarts", "Product_Id");
            DropColumn("dbo.UserCarts", "Owner_Id");
        }
    }
}
