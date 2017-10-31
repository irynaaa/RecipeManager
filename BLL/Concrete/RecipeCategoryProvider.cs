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

       

        public EditRecipeCategoryViewModel EditRecipeCategory(int id)
        {
            EditRecipeCategoryViewModel model = null;

            var category = _recipeCategoryRepository.GetRecipeCategoryById(id);
            
            if (category != null)
            {
                model = new EditRecipeCategoryViewModel
                {
                    Id = category.Id,
                    NameRecipeCategory = category.NameRecipeCategory,
                    IsPublished = category.IsPublished
                };
            }
            return model;
        }

        public int EditRecipeCategory(EditRecipeCategoryViewModel editCategory)
        {
            try
            {
                var category =
                    _recipeCategoryRepository.GetRecipeCategoryById(editCategory.Id);
                if (category != null)
                {
                    category.NameRecipeCategory = editCategory.NameRecipeCategory;
                    category.IsPublished = editCategory.IsPublished;
                    _recipeCategoryRepository.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
            return editCategory.Id;
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

        public void RemoveCategory(int id)
        {
            _recipeCategoryRepository.Remove(id);
        }
    }
}
