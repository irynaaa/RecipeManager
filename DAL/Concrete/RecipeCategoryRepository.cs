using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly IEFContext _context;
        public RecipeCategoryRepository(IEFContext context)
        {
            _context = context;
        }

        public RecipeCategory Add(RecipeCategory category)
        {
            _context.Set<RecipeCategory>().Add(category);
            return category;
        }

        public RecipeCategory GetRecipeCategoryById(int id)
        {
            return this.GettAllRecipeCategories()
                .SingleOrDefault(c => c.Id == id);
        }

        public IQueryable<RecipeCategory> GettAllRecipeCategories(bool published = false)
        {
            return this._context.Set<RecipeCategory>()
                .Where(c => c.IsPublished || c.IsPublished == published);
    }
        public void Remove(int id)
        {
            var category = this.GetRecipeCategoryById(id);
            if (category != null)
            {
                _context.Set<RecipeCategory>().Remove(category);
                this.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
