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
        RecipesViewModel EditRecipeProdWeight(int id);
        RecipesViewModel EditRecipeProdWeight(RecipesViewModel editRecipe);
        void Delete(int id);
        StatusDeleteViewModel DeletePopup(int id);
        int DeleteRecipeProd(int recipeId, int prodId);
        int DeleteRecipeMenu(int recipeId, int menuId);

        IEnumerable<SelectItemViewModel> GetListItemProducts();

       // IEnumerable<SelectItemViewModel> GetListProducts();
        IEnumerable<SelectItemViewModel> GetListItemMenus();

        IEnumerable<SelectProdWeightViewModel> GetListWeightProducts(int id);


        GetRecipeProdItemInfoViewModel GetRecipeProdInfo(int recipeID);
    }
}
