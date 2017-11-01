using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRecipeRepository
    {
        Recipe Add(Recipe recipe);
        //IQueryable<Recipe> Recipes();
        void SaveChanges();
        IQueryable<Recipe> GettAllRecipes();
        Recipe GetRecipeById(int id);
        void Delete(int id);
    }
}
