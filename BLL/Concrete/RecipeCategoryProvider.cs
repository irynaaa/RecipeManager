using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entity;

namespace BLL.Concrete
{
    public class RecipeCategoryProvider: IRecipeCategoryProvider
    {
        IRecipeCategoryRepository _recipeCategoryRepository;

        public RecipeCategoryProvider(IRecipeCategoryRepository recipeCategoryRepository)
        {
            _recipeCategoryRepository = recipeCategoryRepository;
        }

        public int AddCategory(AddCategoryViewModel addCategory)
        {
            RecipeCategory category = new RecipeCategory
            {
                NameRecipeCategory = addCategory.NameRecipeCategory,
                IsPublished = addCategory.IsPublished
            };
            _recipeCategoryRepository.Add(category);
            _recipeCategoryRepository.SaveChanges();

            return category.Id;
        }

        public int EditCategory(CategoryItemViewModel editCategory)
        {
            throw new NotImplementedException();
        }

        public CategoryItemViewModel EditCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryItemViewModel> GetCategories()
        {
            var model = _recipeCategoryRepository.GettAllRecipeCategories(false)
                .Select(c => new CategoryItemViewModel
                {
                    Id = c.Id,
                    NameRecipeCategory = c.NameRecipeCategory,
                    IsPublished = c.IsPublished
                });
            return model.AsEnumerable();
        }

        public CategoryItemViewModel GetCategoryDetails(int id)
        {
            CategoryItemViewModel model = null;
            var category = _recipeCategoryRepository.GetRecipeCategoryById(id);
            if (category != null)
            {
                model = new CategoryItemViewModel
                {
                    Id = category.Id,
                    NameRecipeCategory = category.NameRecipeCategory,
                    IsPublished = category.IsPublished
                };
            }
            return model;
        }


        //public CategoryItemViewModel RemoveCategory(int id)
        //{
        //    var category = _recipeCategoryRepository.Remove(id);
        //    var model_ = new CategoryItemViewModel(category);
        //    return model_;
        //}

        public void RemoveCategory(int id)
        {
            _recipeCategoryRepository.Remove(id);
        }
    }
}
