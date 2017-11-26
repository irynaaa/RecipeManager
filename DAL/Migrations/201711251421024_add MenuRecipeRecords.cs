namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenuRecipeRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords");
            DropForeignKey("dbo.Recipes", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords");
            DropIndex("dbo.Menus", new[] { "MenuRecipeRecord_Id" });
            DropIndex("dbo.Recipes", new[] { "MenuRecipeRecord_Id" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateIndex("dbo.MenuRecipeRecords", "MenuId");
            CreateIndex("dbo.MenuRecipeRecords", "RecipeId");
            AddForeignKey("dbo.MenuRecipeRecords", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuRecipeRecords", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropColumn("dbo.Menus", "MenuRecipeRecord_Id");
            DropColumn("dbo.Recipes", "MenuRecipeRecord_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "MenuRecipeRecord_Id", c => c.Int());
            AddColumn("dbo.Menus", "MenuRecipeRecord_Id", c => c.Int());
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MenuRecipeRecords", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.MenuRecipeRecords", "MenuId", "dbo.Menus");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MenuRecipeRecords", new[] { "RecipeId" });
            DropIndex("dbo.MenuRecipeRecords", new[] { "MenuId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Recipes", "MenuRecipeRecord_Id");
            CreateIndex("dbo.Menus", "MenuRecipeRecord_Id");
            AddForeignKey("dbo.Recipes", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords", "Id");
            AddForeignKey("dbo.Menus", "MenuRecipeRecord_Id", "dbo.MenuRecipeRecords", "Id");
        }
    }
}
