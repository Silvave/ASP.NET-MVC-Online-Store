namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIsDeletedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "IsDeleted", c => c.Boolean(nullable: false, defaultValue:false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Addresses", "IsDeleted");
        }
    }
}
