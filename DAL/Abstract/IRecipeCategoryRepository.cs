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
        void Remove(int id);
        //RecipeCategory Details(int id);

        //Category Edit(int id);
        //Category Edit(Category category);
        RecipeCategory GetRecipeCategoryById(int id);
        IEnumerable<RecipeCategory> GettAllRecipeCategories(bool published = true);
        void SaveChanges();
    }
}
