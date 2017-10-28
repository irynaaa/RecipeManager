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
        public RecipeCategory Add(RecipeCategory category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RecipeCategory> GettAllRecipeCategory(bool published = true)
        {
            throw new NotImplementedException();
        }

        public void Remove(RecipeCategory category)
        {
            throw new NotImplementedException();
        }

        public RecipeCategory Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
