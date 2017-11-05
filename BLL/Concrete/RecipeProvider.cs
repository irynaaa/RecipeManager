using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Entity;
using System.Transactions;
namespace BLL.Concrete
{
    public class RecipeProvider : IRecipeProvider
    {
        IProductRepository _productRepository;
        IRecipeRepository _recipeRepository;
        IRecipeCategoryRepository _recipeCategoryRepository;
        IRecipeProdRecordRepository _recipeProdRecordRepository;

        public RecipeProvider(IRecipeRepository recipeRepository,
                              IRecipeCategoryRepository recipeCategoryRepository,
                              IProductRepository productRepository,
                              IRecipeProdRecordRepository recipeProdRecordRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
            _recipeProdRecordRepository = recipeProdRecordRepository;
            _productRepository = productRepository;
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
                RecipeCategory = addRecipe.RecipeCategory,
            };

            _recipeRepository.Add(recipe);
            _recipeRepository.SaveChanges();

            return recipe.Id;
        }

        public RecipesViewModel GetRecipeDetales(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);

            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = GetSelectCategories();
            if (recipe != null)
            {
                var MyViewModel = new RecipesViewModel();
                MyViewModel.Id = id;
                MyViewModel.RecipeName = recipe.RecipeName;
                MyViewModel.RecipeImage = recipe.RecipeImage;
                MyViewModel.RecipeDescription = recipe.RecipeDescription;
                MyViewModel.CreatedAt = recipe.CreatedAt;
                MyViewModel.ModefiedAt = recipe.ModefiedAt;
                MyViewModel.CookingTime = recipe.CookingTime;
                MyViewModel.RecipeCategory = recipe.RecipeCategory;
                MyViewModel.Products = recipe.RecipeProdRecords.Select(pr => new SelectItemViewModel
                {
                    Id = pr.ProductId,
                    Name = pr.Product.ProductName,
                });

                return MyViewModel;
            }

            return null;
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
                    RecipeCategoryId = recipe.RecipeCategoryId,
                    RecipeCategory = recipe.RecipeCategory,
                   
                    Products = recipe.RecipeProdRecords.Select(p => p.ProductId).ToList()
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
                    using (var transaction = new TransactionScope())
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

                        List<int> prodIdlist = new List<int>();
                        foreach (var item in recipe.RecipeProdRecords)
                        {
                            prodIdlist.Add(item.Id);

                        }

                        foreach (var item in prodIdlist)
                        {
                            _recipeProdRecordRepository.Remove(item);

                        }

                        _recipeProdRecordRepository.SaveChanges();
                        _recipeProdRecordRepository.SaveChanges();

                        foreach (var item in editRecipe.Products)
                        {
                            var prod = _productRepository.GetProductById(item);
                            if (prod != null)
                                _recipeProdRecordRepository.Add(new RecipeProdRecord() { RecipeId = editRecipe.Id, ProductId = item });
                        }

                        _recipeProdRecordRepository.SaveChanges();
                        _recipeRepository.SaveChanges();
                        transaction.Complete();
                    }

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


        public IEnumerable<RecipesViewModel> GetRecipes()
        {
            var recipe = _recipeRepository.GettAllRecipes()
                .Select(p => new RecipesViewModel
                {
                    Id = p.Id,
                    RecipeName = p.RecipeName,
                    RecipeImage = p.RecipeImage,
                    RecipeDescription = p.RecipeDescription,
                    CreatedAt = p.CreatedAt,
                    ModefiedAt = p.ModefiedAt,
                    CookingTime = p.CookingTime,
                    RecipeCategoryId = p.Id,
                    RecipeCategory = p.RecipeCategory,
                   
                    Products = p.RecipeProdRecords.Select(pr => new SelectItemViewModel
                    {
                        Id = pr.ProductId,
                        Name = pr.Product.ProductName,
                    })
                });

            return recipe;
        }


        public int DeleteRecipeProd(int recipeId, int prodId)
        {

            var prod = _productRepository.GetProductById(prodId);
            if (prod != null)
            {
                var recipe = _recipeRepository.GetRecipeById(recipeId);
                if (recipe != null)
                {
                    _recipeProdRecordRepository.Remove(_recipeProdRecordRepository.RecipeProdRecords()
                        .FirstOrDefault(rpr => rpr.ProductId == prodId && rpr.RecipeId == recipeId).Id);

                    _recipeRepository.SaveChanges();
                    _recipeProdRecordRepository.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }


        public IEnumerable<SelectItemViewModel> GetListItemProducts()
        {
            return _productRepository.Products()
                .Select(r => new SelectItemViewModel
                {
                    Id = r.Id,
                    Name = r.ProductName
                });
        }


        public IEnumerable<SelectItemViewModel> GetListProducts()
        {
            return _recipeRepository.RecipeProdRecords()
                .Select(r => new SelectItemViewModel
                {
                    Id = r.Product.Id,
                    Name = r.Product.ProductName
                });
        }



    }
}
