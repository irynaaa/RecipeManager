using BLL.Abstract;
using BLL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Areas.Admin.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Admin/Recipe

        private readonly IRecipeProvider _recipeProvider;

        public RecipeController(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }
        // GET: Category

        public ActionResult Index(/*int? page*/)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");


            var model = _recipeProvider.GetRecipes().OrderBy(i => i.Id);
            // int pageSize = 10;
            // int pageNumber = (page ?? 1);
            //return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
            return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id));
        }


        [HttpPost]
        public ActionResult Index(/*int? page,*/ int? categoryId)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            var model = _recipeProvider.GetRecipes().OrderBy(i => i.Id);

           // int pageSize = 10;
           // int pageNumber = (page ?? 1);
            if (categoryId != null)
                return View(_recipeProvider.GetRecipes().Where(recipe => recipe.RecipeCategoryId == categoryId).OrderBy(i => i.Id));//.ToPagedList(pageNumber, pageSize));
            else
                return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id));//.ToPagedList(pageNumber, pageSize));
        }

        // [ValidateAntiForgeryToken]
        public ActionResult Add()
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            var viewModel = new AddRecipeViewModel
            {
                CreatedAt = DateTime.Now,
                ModefiedAt = DateTime.Now,
                Categories = categoriesList
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddRecipeViewModel recipe)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
                categoriesList = _recipeProvider.GetSelectCategories();

                var viewModel = new AddRecipeViewModel
                {
                    RecipeName = recipe.RecipeName,
                    RecipeImage=recipe.RecipeImage,
                    RecipeDescription = recipe.RecipeDescription,
                    CreatedAt = recipe.CreatedAt,
                    ModefiedAt = recipe.ModefiedAt,
                    CookingTime=recipe.CookingTime,
                    RecipeCategoryId = recipe.RecipeCategoryId,
                    Categories = categoriesList

                };
                return View("Add", viewModel);
            }
            _recipeProvider.AddRecipe(recipe);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _recipeProvider.GetRecipeDetales(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecipesViewModel recipeDel)
        {
            _recipeProvider.Delete(recipeDel.Id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _recipeProvider.GetRecipeDetales(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _recipeProvider.EditRecipe(id);
            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRecipeViewModel editRecipe)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            editRecipe.Categories = categoriesList;

            if (ModelState.IsValid)
            {
                var result = _recipeProvider.EditRecipe(editRecipe);

                if (result == 0)
                {
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить!");
                }
                else if (result != 0)
                    return RedirectToAction("Index");
            }
            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();

            return View(editRecipe);
        }


        [HttpPost]
        public ContentResult DeleteRecipeProd(int recipeId, int prodId)
        {
            string json = "";
           
            int rez = _recipeProvider.DeleteRecipeProd(recipeId, prodId);

            json = JsonConvert.SerializeObject(new
            {
                rez = rez
            });
            return Content(json, "application/json");
        }
    }
}