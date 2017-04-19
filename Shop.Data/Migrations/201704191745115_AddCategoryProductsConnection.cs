namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiscMigrattion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCategories", newName: "CategoryProducts");
            DropPrimaryKey("dbo.CategoryProducts");
            AddPrimaryKey("dbo.CategoryProducts", new[] { "Category_Id", "Product_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CategoryProducts");
            AddPrimaryKey("dbo.CategoryProducts", new[] { "Product_Id", "Category_Id" });
            RenameTable(name: "dbo.CategoryProducts", newName: "ProductCategories");
        }
    }
}
