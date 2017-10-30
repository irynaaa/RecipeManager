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
        //int RemoveCategory(CategoryItemViewModel removeCategory);
        void RemoveCategory(int id);
        CategoryItemViewModel EditCategory(int id);
        int EditCategory(CategoryItemViewModel editCategory);
        CategoryItemViewModel GetCategoryDetails(int id);
    }
}
