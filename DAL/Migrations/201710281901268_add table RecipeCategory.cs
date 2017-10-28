namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableRecipeCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRecipeCategory = c.String(nullable: false, maxLength: 255),
                        IsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "RecipeCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "RecipeCategoryId");
            AddForeignKey("dbo.Recipes", "RecipeCategoryId", "dbo.RecipeCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeCategoryId", "dbo.RecipeCategories");
            DropIndex("dbo.Recipes", new[] { "RecipeCategoryId" });
            DropColumn("dbo.Recipes", "RecipeCategoryId");
            DropTable("dbo.RecipeCategories");
        }
    }
}
