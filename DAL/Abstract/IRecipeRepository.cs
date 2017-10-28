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
        Recipe Remove(Recipe recipe);
        IQueryable<Recipe> Recipes();
    }
}
