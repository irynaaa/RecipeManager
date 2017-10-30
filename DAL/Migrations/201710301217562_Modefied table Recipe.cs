namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModefiedtableRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "ModefiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "CookingTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "CookingTime");
            DropColumn("dbo.Recipes", "ModefiedAt");
            DropColumn("dbo.Recipes", "CreatedAt");
        }
    }
}
