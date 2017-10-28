using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class RecipeRepository : IRecipeRepository
    {
        public Recipe Add(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Recipe> Recipes()
        {
            throw new NotImplementedException();
        }

        public Recipe Remove(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
