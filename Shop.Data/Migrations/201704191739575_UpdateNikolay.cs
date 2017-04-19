namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNikolay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CommentLikes", "CommentId", "dbo.Comments");
            DropPrimaryKey("dbo.CommentLikes");
            DropPrimaryKey("dbo.ProductLikes");
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary());
            AlterColumn("dbo.Products", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CommentLikes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductLikes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 30));
            AddPrimaryKey("dbo.CommentLikes", "Id");
            AddPrimaryKey("dbo.ProductLikes", "Id");
            AddForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommentLikes", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentLikes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.ProductLikes");
            DropPrimaryKey("dbo.CommentLikes");
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.ProductLikes", "Id");
            DropColumn("dbo.CommentLikes", "Id");
            DropColumn("dbo.Products", "Deleted");
            DropColumn("dbo.Products", "ProductImage");
            AddPrimaryKey("dbo.ProductLikes", "ProductId");
            AddPrimaryKey("dbo.CommentLikes", "CommentId");
            AddForeignKey("dbo.CommentLikes", "CommentId", "dbo.Comments", "Id");
            AddForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products", "Id");
        }
    }
}
