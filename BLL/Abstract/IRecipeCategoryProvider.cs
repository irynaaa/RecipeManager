using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IRecipeCategoryProvider
    {
        IEnumerable<CategoryItemViewModel> GetCategories();
        int AddCategory(AddCategoryViewModel addCategory);
        void RemoveCategory(int id);
        EditRecipeCategoryViewModel EditRecipeCategory(int id);
        int EditRecipeCategory(EditRecipeCategoryViewModel editCategory);
        CategoryItemViewModel GetCategoryDetails(int id);
    }
}
