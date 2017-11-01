namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpropertyIsPublishedtoMenutable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "IsPublished");
        }
    }
}
