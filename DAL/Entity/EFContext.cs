using DAL.Abstract;
using DAL.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EFContext : /*DbContext,*/IdentityDbContext<AppUser>, IEFContext
    {
        public EFContext() : base("RecipeManagerDB_ConnectionString")
        {
            //  Database.SetInitializer<EFContext>(null);
        }
        public EFContext(string conName) : base(conName)
        {
            Database.SetInitializer<EFContext>(null);
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeProdRecord> RecipeProdRecords { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuRecipeRecord> MenuRecipeRecords { get; set; }

        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        //??
        //public DbSet<ApplicationUser> ApplicationUser { get; set; }

        IDbSet<TEntity> IEFContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
