using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Entity;

namespace BLL.Concrete
{
   public class RecipeProvider: IRecipeProvider
    {
        IRecipeRepository _recipeRepository;
        IRecipeCategoryRepository _recipeCategoryRepository;
        public RecipeProvider(IRecipeRepository recipeRepository, IRecipeCategoryRepository recipeCategoryRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
        }

        public IEnumerable<SelectItemViewModel> GetSelectCategories()
        {
            return _recipeCategoryRepository.GettAllRecipeCategories()
                .Select(c => new SelectItemViewModel
                {
                    Id = c.Id,
                    Name = c.NameRecipeCategory,

                });
        }

        public int AddRecipe(AddRecipeViewModel addRecipe)
        {
            var selecteditem = GetSelectCategories();
            var item = new SelectItemViewModel();

            Recipe recipe = new Recipe
            {
                RecipeName = addRecipe.RecipeName,
                RecipeImage = addRecipe.RecipeImage,
                RecipeDescription = addRecipe.RecipeDescription,
                CreatedAt = DateTime.Now,
                ModefiedAt = DateTime.Now,
                CookingTime = addRecipe.CookingTime,
               
                RecipeCategoryId = addRecipe.RecipeCategoryId,
                RecipeCategory= addRecipe.RecipeCategory,
            };

            _recipeRepository.Add(recipe);
            _recipeRepository.SaveChanges();

            return recipe.Id;
        }

        IEnumerable<RecipesViewModel> IRecipeProvider.GetRecipes()
        {
            Recipe recipe = new Recipe();
            var model = _recipeRepository.GettAllRecipes()
                .Select(c => new RecipesViewModel
                {
                    Id = c.Id,
                    RecipeName = c.RecipeName,
                    RecipeImage = c.RecipeImage,
                    RecipeDescription = c.RecipeDescription,
                    CreatedAt = c.CreatedAt,
                    ModefiedAt = c.ModefiedAt,
                    CookingTime = c.CookingTime,
                    RecipeCategoryId=c.Id,
                    RecipeCategory=c.RecipeCategory
                });

            return model.AsEnumerable();
        }

        public RecipesViewModel GetRecipeDetales(int id)
        {
            RecipesViewModel model = null;
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe != null)
            {
                model = new RecipesViewModel
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    RecipeImage = recipe.RecipeImage,
                    RecipeDescription = recipe.RecipeDescription,
                    CreatedAt = recipe.CreatedAt,
                    ModefiedAt = recipe.ModefiedAt,
                    CookingTime = recipe.CookingTime,
                    RecipeCategory = recipe.RecipeCategory
                };
            }
            return model;
        }

        public EditRecipeViewModel EditRecipe(int id)
        {
            EditRecipeViewModel model = null;

            var recipe = _recipeRepository.GetRecipeById(id);
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = GetSelectCategories();
            if (recipe != null)
            {
                model = new EditRecipeViewModel
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    RecipeImage = recipe.RecipeImage,
                    RecipeDescription = recipe.RecipeDescription,
                    CreatedAt = recipe.CreatedAt,
                    ModefiedAt = DateTime.Now,
                    CookingTime = recipe.CookingTime,
                    Categories = categoriesList,
                    RecipeCategoryId =recipe.RecipeCategoryId,
                    RecipeCategory = recipe.RecipeCategory
                };
            }
            return model;
        }

        public int EditRecipe(EditRecipeViewModel editRecipe)
        {
            try
            {
                var recipe =
                    _recipeRepository.GetRecipeById(editRecipe.Id);
                if (recipe != null)
                {
                    recipe.Id = editRecipe.Id;
                    recipe.RecipeName = editRecipe.RecipeName;
                    recipe.RecipeImage = editRecipe.RecipeImage;
                    recipe.RecipeDescription = editRecipe.RecipeDescription;
                    recipe.CreatedAt = editRecipe.CreatedAt;
                    recipe.ModefiedAt = DateTime.Now;
                    recipe.CookingTime = editRecipe.CookingTime;
                    recipe.RecipeCategoryId = editRecipe.RecipeCategoryId;
                    recipe.RecipeCategory = editRecipe.RecipeCategory;

                    _recipeRepository.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
            return editRecipe.Id;
        }

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }
    }
}
