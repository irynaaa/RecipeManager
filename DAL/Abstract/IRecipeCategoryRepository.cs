using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IRecipeCategoryRepository
    {
        RecipeCategory Add(RecipeCategory category);
        RecipeCategory Remove(int id);
        void Remove(RecipeCategory category);
        //Category Details(int id);

        //Category Edit(int id);
        //Category Edit(Category category);

        IQueryable<RecipeCategory> GettAllRecipeCategory(bool published = true);
    }
}
