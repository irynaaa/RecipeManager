namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpropertyRecipeDescriptiontoRecipetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "RecipeDescription", c => c.String(maxLength: 3000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "RecipeDescription");
        }
    }
}
