using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IRecipeProvider
    {
        IEnumerable<RecipesViewModel> GetRecipes();
        int AddRecipe(AddRecipeViewModel addRecipe);
        IEnumerable<SelectItemViewModel> GetSelectCategories();
        RecipesViewModel GetRecipeDetales(int id);
        EditRecipeViewModel EditRecipe(int id);
        int EditRecipe(EditRecipeViewModel editRecipe);
        void Delete(int id);
    }
}
