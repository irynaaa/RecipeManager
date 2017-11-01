using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IEFContext _context;
        public RecipeRepository(IEFContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public Recipe Add(Recipe recipe)
        {
            _context.Set<Recipe>().Add(recipe);
            return recipe;
        }

        public void Delete(int id)
        {
            var recipe = this.GetRecipeById(id);
            if (recipe != null)
            {
                _context.Set<Recipe>().Remove(recipe);
                this.SaveChanges();
            }
        }

        public Recipe GetRecipeById(int id)
        {
            return this.GettAllRecipes()
               .SingleOrDefault(c => c.Id == id);
        }

        public IQueryable<Recipe> GettAllRecipes()
        {
            return this._context.Set<Recipe>().Include(c => c.RecipeCategory);
        }

     

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
