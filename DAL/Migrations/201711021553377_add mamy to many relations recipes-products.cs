namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmamytomanyrelationsrecipesproducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "RecipeProdRecord_Id", "dbo.RecipeProdRecords");
            DropForeignKey("dbo.Recipes", "RecipeProdRecord_Id", "dbo.RecipeProdRecords");
            DropIndex("dbo.Recipes", new[] { "RecipeProdRecord_Id" });
            DropIndex("dbo.Products", new[] { "RecipeProdRecord_Id" });
            CreateIndex("dbo.RecipeProdRecords", "ProductId");
            CreateIndex("dbo.RecipeProdRecords", "RecipeId");
            AddForeignKey("dbo.RecipeProdRecords", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeProdRecords", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropColumn("dbo.Recipes", "RecipeProdRecord_Id");
            DropColumn("dbo.Products", "RecipeProdRecord_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "RecipeProdRecord_Id", c => c.Int());
            AddColumn("dbo.Recipes", "RecipeProdRecord_Id", c => c.Int());
            DropForeignKey("dbo.RecipeProdRecords", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeProdRecords", "ProductId", "dbo.Products");
            DropIndex("dbo.RecipeProdRecords", new[] { "RecipeId" });
            DropIndex("dbo.RecipeProdRecords", new[] { "ProductId" });
            CreateIndex("dbo.Products", "RecipeProdRecord_Id");
            CreateIndex("dbo.Recipes", "RecipeProdRecord_Id");
            AddForeignKey("dbo.Recipes", "RecipeProdRecord_Id", "dbo.RecipeProdRecords", "Id");
            AddForeignKey("dbo.Products", "RecipeProdRecord_Id", "dbo.RecipeProdRecords", "Id");
        }
    }
}
