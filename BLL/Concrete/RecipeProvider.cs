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

        //IEnumerable<ProdItemViewModel> GetProdRecipes()
        //{
        //   var prods = _recipeRepository.GettAllRecipes()
        //        .Select(c => new RecipesViewModel
        //        {
        //            Id = c.Id,
        //            RecipeName = c.RecipeName,
        //            RecipeImage = c.RecipeImage,
        //            RecipeDescription = c.RecipeDescription,
        //            CreatedAt = c.CreatedAt,
        //            ModefiedAt = c.ModefiedAt,
        //            CookingTime = c.CookingTime,
        //            RecipeCategoryId = c.Id,
        //            RecipeCategory = c.RecipeCategory,

        //            Products = GetRecipeProducts().Select(p => new ProdItemViewModel
        //            {
        //                Id = p.Id,
        //                Name = p.Name
        //            })
        //        });

        //    List<ProdItemViewModel> model = new List<ProdItemViewModel>();
        //    foreach(var p in prods)
        //    {
        //        model.Add(new ProdItemViewModel() { Id = p.Id, Name = p.RecipeName });
        //    }

        //    return model.AsEnumerable();
        //}

        public RecipesViewModel GetRecipeDetales(int id)
        {
           // RecipesViewModel model = null;
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe != null)
            {
                var Results = from p in _productRepository.Products()
                              select new
                              {
                                  p.Id,
                                  p.ProductName,
                                  IsChecked = ((from pr in _recipeRepository.RecipeProdRecords()
                                                where (pr.ProductId == p.Id) & (pr.RecipeId == id)
                                                select pr).Count() > 0)
                              };

                var MyViewModel = new RecipesViewModel();
                MyViewModel.Id = id;
                MyViewModel.RecipeName = recipe.RecipeName;
                MyViewModel.RecipeImage = recipe.RecipeImage;
                MyViewModel.RecipeDescription = recipe.RecipeDescription;
                MyViewModel.CreatedAt = recipe.CreatedAt;
                MyViewModel.ModefiedAt = recipe.ModefiedAt;
                MyViewModel.CookingTime = recipe.CookingTime;
                MyViewModel.RecipeCategory = recipe.RecipeCategory;
                var MyCheckBoxList = new List<CheckBoxViewModel>();
                foreach (var item in Results)
                {
                    MyCheckBoxList.Add(new CheckBoxViewModel()
                    {
                        Id = item.Id,
                        Name = item.ProductName,
                        IsChecked = item.IsChecked
                    });
                 }
                MyViewModel.Products = MyCheckBoxList;
                return MyViewModel;
                }
            return null;
            }
           

            //model = new RecipesViewModel
            //{
            //    Id = recipe.Id,
            //    RecipeName = recipe.RecipeName,
            //    RecipeImage = recipe.RecipeImage,
            //    RecipeDescription = recipe.RecipeDescription,
            //    CreatedAt = recipe.CreatedAt,
            //    ModefiedAt = recipe.ModefiedAt,
            //    CookingTime = recipe.CookingTime,
            //    RecipeCategory = recipe.RecipeCategory
            //};
        //}
        //    return model;
        //}

    public EditRecipeViewModel EditRecipe(int id)
    {
        EditRecipeViewModel model = null;


            //////////////
            var recipe = _recipeRepository.GetRecipeById(id);

            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = GetSelectCategories();

            //var MyViewModel = new EditRecipeViewModel();
            //if (recipe != null)
            //{
            //    var Results = from p in _productRepository.Products()
            //                  select new
            //                  {
            //                      p.Id,
            //                      p.ProductName,
            //                      IsChecked = ((from pr in _recipeProdRecordRepository.RecipeProdRecords()
            //                                    where (pr.ProductId == p.Id) & (pr.RecipeId == id)
            //                                    select pr).Count() > 0)
            //                  };

            //    MyViewModel.Id = id;
            //    MyViewModel.RecipeName = recipe.RecipeName;
            //    MyViewModel.RecipeImage = recipe.RecipeImage;
            //    MyViewModel.RecipeDescription = recipe.RecipeDescription;
            //    MyViewModel.CreatedAt = recipe.CreatedAt;
            //    MyViewModel.ModefiedAt = recipe.ModefiedAt;
            //    MyViewModel.CookingTime = recipe.CookingTime;
            //    MyViewModel.RecipeCategory = recipe.RecipeCategory;
            //    MyViewModel.Categories = categoriesList;
            //    MyViewModel.RecipeCategoryId = recipe.RecipeCategoryId;

            //    var MyCheckBoxList = new List<CheckBoxViewModel>();

            //    foreach (var item in Results)
            //    {
            //        MyCheckBoxList.Add(new CheckBoxViewModel()
            //        {
            //            Id = item.Id,
            //            Name = item.ProductName,
            //            IsChecked = item.IsChecked
            //        });
            //    }
            //    MyViewModel.Products = MyCheckBoxList;

            //}

            ///////////////////

            //    var recipe = _recipeRepository.GetRecipeById(id);
            //IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            //categoriesList = GetSelectCategories();
            //if (recipe != null)
            //{
            //    model = new EditRecipeViewModel
            //    {
            //        Id = recipe.Id,
            //        RecipeName = recipe.RecipeName,
            //        RecipeImage = recipe.RecipeImage,
            //        RecipeDescription = recipe.RecipeDescription,
            //        CreatedAt = recipe.CreatedAt,
            //        ModefiedAt = DateTime.Now,
            //        CookingTime = recipe.CookingTime,
            //        Categories = categoriesList,
            //        RecipeCategoryId = recipe.RecipeCategoryId,
            //        RecipeCategory = recipe.RecipeCategory
            //    };
            //}

            /* var ShowProducts =
            from mpl in myplateRep.MyPlates().AsEnumerable()
            join r in platefoodrecordRepositoryRep.PlateFoodRecords().AsEnumerable() on mpl.Id equals r.PlateId
            join p in foodRep.Products().AsEnumerable() on r.FoodId equals p.Id
            where mpl.mealtime.Month == t.Value.Month
            select new
            {
                time = mpl.mealtime,
                food = p.FoodName,
                proteins = p.Proteins * r.Weight / 100,
                fats = p.Fat * r.Weight / 100,
                carbohydrates = p.Carbohydrates * r.Weight / 100,
                call = p.CaloricValue * r.Weight / 100
            };

            foreach (var p in ShowProducts.OrderBy(x => x.time.Day).ThenBy(x => x.time.Hour))//отсортировала время по возрастанию
            {
                items_.Add(new PlateItems() { _time =p.time, _food = p.food, _proteins = p.proteins, _fats = p.fats, _carbohydrates = p.carbohydrates, _call = p.call });
                
            }*/

            if (recipe != null)
            {

                var Results = from p in _productRepository.Products().AsEnumerable()
                              select new 
                              {
                                  p.Id,
                                  p.ProductName,
                                  IsChecked=false
                                  //IsChecked = ((from pr in _recipeProdRecordRepository.RecipeProdRecords().AsEnumerable()
                                  //              where (pr.RecipeId == id)&(pr.ProductId == p.Id)  
                                  //              select pr).Count() > 0)
                              };

                var MyCheckBoxList = new List<CheckBoxViewModel>();

                foreach (var item in Results)
                {
                    MyCheckBoxList.Add(new CheckBoxViewModel()
                    {
                        Id = item.Id,
                        Name = item.ProductName,
                        IsChecked = item.IsChecked
                    });
                }
             //    MyViewModel.Products = MyCheckBoxList;
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
                    Products = MyCheckBoxList
                };
            }

                return model/*MyViewModel*/;
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

                    foreach(var item in editRecipe.Products)
                    {
                        if(item.IsChecked)
                        {
                            _recipeProdRecordRepository.Add(new RecipeProdRecord() { RecipeId = editRecipe.Id, ProductId = item.Id });
                        }
                    }
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

        //public IEnumerable<SelectItemViewModel> GetListItemProducts()
        //{
        //    return GetProducts().AsEnumerable()
        //        .Select(r => new SelectItemViewModel
        //        {
        //            Id = r.Id,
        //            Name = r.ProductName
        //        });
        //}


        //public IEnumerable<ProdItemViewModel> GetRecipeProducts()
        //{
        //    List<ProdItemViewModel> products = new List<ProdItemViewModel>();
        //    var RecipeProducts =
        //        from recipes in _recipeRepository.GettAllRecipes().AsEnumerable()
        //        join recipe_prod in _recipeProdRecordRepository.RecipeProdRecords().AsEnumerable()
        //        on recipes.Id equals recipe_prod.RecipeId
        //        join prod in _productRepository.Products().AsEnumerable()
        //         on recipe_prod.ProductId equals prod.Id
        //        select new
        //        {
        //            Id = prod.Id,
        //            Name = prod.ProductName
        //        };

        //    foreach (var p in RecipeProducts)
        //    {
        //        products.Add(new ProdItemViewModel() { Id = p.Id, Name = p.Name });
        //    }
        //    return products.AsEnumerable();

        //}

        /* public IEnumerable<UserItemViewModel> GetAllUsers()
                {
                IEnumerable<UserItemViewModel> users =
                   _userRepository.GetAllUsers()
                   .Select(u => new UserItemViewModel
                   {
                       Id = u.Id,
                       Email = u.Email,
                       Roles = u.Roles.Select(r => new RoleItemViewModel
                       {
                           Id = r.Id,
                           Name = r.Name
                       })
                   });
                    return users;*/

        public IEnumerable<RecipesViewModel> GetRecipes()
    {
            var recipe = _recipeRepository.GettAllRecipes()
                .Select(p=> new RecipesViewModel
                {
                    Id = p.Id,
                    RecipeName = p.RecipeName,
                    RecipeImage = p.RecipeImage,
                    RecipeDescription =p.RecipeDescription,
                    CreatedAt = p.CreatedAt,
                    ModefiedAt = p.ModefiedAt,
                    CookingTime = p.CookingTime,
                    RecipeCategoryId = p.Id,
                    RecipeCategory = p.RecipeCategory,
                    Products = p.RecipeProdRecords.Select(pr=>new CheckBoxViewModel
                    {
                        Id=pr.Id,
                        Name=pr.Product.ProductName,
                        IsChecked=true
                    })
                });
           
            //    var Results = from p in _productRepository.Products()
            //                  select new
            //                  {
            //                      p.Id,
            //                      p.ProductName,

            //                      IsChecked = ((from pr in _recipeProdRecordRepository.RecipeProdRecords()
            //                                    where (pr.ProductId == p.Id)/* & (pr.RecipeId == id)*/
            //                                    select pr).Count() > 0)
            //                  };

            //    var MyCheckBoxList = new List<CheckBoxViewModel>();
            //try
            //{
            //    foreach (var item in Results)
            //    {
            //        MyCheckBoxList.Add(new CheckBoxViewModel()
            //        {
            //            Id = item.Id,
            //            Name = item.ProductName,
            //            IsChecked = item.IsChecked
            //        });
            //    }
            //}
            //catch
            //{

            //}
            //var model = _recipeRepository.GettAllRecipes()
            //.Select(c => new RecipesViewModel
            //{
            //    Id = c.Id,
            //    RecipeName = c.RecipeName,
            //    RecipeImage = c.RecipeImage,
            //    RecipeDescription = c.RecipeDescription,
            //    CreatedAt = c.CreatedAt,
            //    ModefiedAt = c.ModefiedAt,
            //    CookingTime = c.CookingTime,
            //    RecipeCategoryId = c.Id,
            //    RecipeCategory = c.RecipeCategory,
            //    Products = MyCheckBoxList.AsEnumerable()
            //});
           
            return /*model.AsEnumerable()*/ recipe;
    }
}
}
