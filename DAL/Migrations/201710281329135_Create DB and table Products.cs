namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDBandtableProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuRecipeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false, maxLength: 255),
                        MenuRecipeRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuRecipeRecords", t => t.MenuRecipeRecord_Id)
                .Index(t => t.MenuRecipeRecord_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false, maxLength: 255),
                        RecipeImage = c.String(maxLength: 255),
                        MenuRecipeRecord_Id = c.Int(),
                        RecipeProdRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuRecipeRecords", t => t.MenuRecipeRecord_Id)
                .ForeignKey("dbo.RecipeProdRecords", t => t.RecipeProdRecord_Id)
                .Index(t => t.MenuRecipeRecord_Id)
                .Index(t => t.RecipeProdRecord_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Proteins = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        CaloricValue = c.Single(nullable: false),
                        RecipeProdRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeProdRecords", t => t.RecipeProdRecord_Id)
                .Index(t => t.RecipeProdRecord_Id);
            
            CreateTable(
                "dbo.RecipeProdRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeProdRecord_Id", "dbo.RecipeProdRecords");
            DropForeignKey("dbo.Products", "RecipeProdRecord_Id", "dbo.RecipeProdRecords");
            DropForeignKey("dbo.Recipes", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords");
            DropForeignKey("dbo.Menus", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords");
            DropIndex("dbo.Products", new[] { "RecipeProdRecord_Id" });
            DropIndex("dbo.Recipes", new[] { "RecipeProdRecord_Id" });
            DropIndex("dbo.Recipes", new[] { "MenuRecipeRecord_Id" });
            DropIndex("dbo.Menus", new[] { "MenuRecipeRecord_Id" });
            DropTable("dbo.RecipeProdRecords");
            DropTable("dbo.Products");
            DropTable("dbo.Recipes");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuRecipeRecords");
        }
    }
}
