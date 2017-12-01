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
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BLL.Concrete
{
    public class RecipeProvider : IRecipeProvider
    {
        IProductRepository _productRepository;
        IRecipeRepository _recipeRepository;
        IMenuRepository _menuRepository;
        IRecipeCategoryRepository _recipeCategoryRepository;
        IRecipeProdRecordRepository _recipeProdRecordRepository;
        IMenuRecipeRecordRepository _menuRecipeRecordRepository;

        public RecipeProvider(IRecipeRepository recipeRepository,
                              IRecipeCategoryRepository recipeCategoryRepository,
                              IProductRepository productRepository,
                              IMenuRepository menuRepository,
                              IRecipeProdRecordRepository recipeProdRecordRepository,
                              IMenuRecipeRecordRepository menuRecipeRecordRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
            _recipeProdRecordRepository = recipeProdRecordRepository;
            _productRepository = productRepository;
            _menuRepository = menuRepository;
            _menuRecipeRecordRepository = menuRecipeRecordRepository;
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
                RecipeDescription = addRecipe.RecipeDescription.Replace("../..", ""),
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

                MyViewModel.Menus = recipe.MenuRecipeRecords.Select(mr => new SelectItemViewModel
                {
                    Id = mr.MenuId,
                    Name = mr.Menu.MenuName,
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
                    ModefiedAt = recipe.ModefiedAt,
                    CookingTime = recipe.CookingTime,
                    RecipeCategoryId = recipe.RecipeCategoryId,
                    Categories = categoriesList,
                    RecipeCategory = recipe.RecipeCategory,

                    Products = recipe.RecipeProdRecords.Select(p => p.ProductId).ToList(),
                    Menus = recipe.MenuRecipeRecords.Select(p => p.MenuId).ToList()

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
                        recipe.RecipeImage = editRecipe.RecipeImage?? recipe.RecipeImage;
                        recipe.RecipeDescription = editRecipe.RecipeDescription;
                        recipe.CreatedAt = editRecipe.CreatedAt;
                        recipe.ModefiedAt = DateTime.Now;
                        recipe.CookingTime = editRecipe.CookingTime;
                        recipe.RecipeCategoryId = editRecipe.RecipeCategoryId;

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
                        _recipeRepository.SaveChanges();

                        foreach (var item in editRecipe.Products)
                        {
                            var prod = _productRepository.GetProductById(item);
                            if (prod != null)
                                _recipeProdRecordRepository.Add(new RecipeProdRecord() { RecipeId = editRecipe.Id, ProductId = item });
                        }



                        List<int> menuIdlist = new List<int>();
                        foreach (var item in recipe.MenuRecipeRecords)
                        {
                            menuIdlist.Add(item.Id);

                        }

                        foreach (var item in menuIdlist)
                        {
                            _menuRecipeRecordRepository.Remove(item);

                        }

                        _menuRecipeRecordRepository.SaveChanges();
                        _recipeRepository.SaveChanges();

                        foreach (var item in editRecipe?.Menus)
                        {
                            var menu = _menuRepository.GetMenuById(item);
                            if (menu != null)
                                _menuRecipeRecordRepository.Add(new MenuRecipeRecord() { RecipeId = editRecipe.Id, MenuId = item });
                        }




                        _menuRecipeRecordRepository.SaveChanges();
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
                    RecipeImage = p.RecipeImage?? "/Images/Recipe/Big/noimage.JPEG",
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
                    }),

                     Menus = p.MenuRecipeRecords.Select(mr => new SelectItemViewModel
                     {
                         Id = mr.MenuId,
                         Name = mr.Menu.MenuName,
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


        public int DeleteRecipeMenu(int recipeId, int menuId)
        {

            var prod = _menuRepository.GetMenuById(menuId);
            if (prod != null)
            {
                var recipe = _recipeRepository.GetRecipeById(recipeId);
                if (recipe != null)
                {
                    _menuRecipeRecordRepository.Remove(_menuRecipeRecordRepository.MenuRecipeRecords()
                        .FirstOrDefault(rpr => rpr.MenuId == menuId && rpr.RecipeId == recipeId).Id);

                    _recipeRepository.SaveChanges();
                    _menuRecipeRecordRepository.SaveChanges();
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

        public IEnumerable<SelectItemViewModel> GetListItemMenus()
        {
            return _menuRepository.Menus()
                .Select(r => new SelectItemViewModel
                {
                    Id = r.Id,
                    Name = r.MenuName
                });
        }

    }
}
