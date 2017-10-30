using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Controllers
{
    public class CategoryController : Controller
    {
        //// GET: Category
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly IRecipeCategoryProvider _recipeCategoryProvider;
        public CategoryController(IRecipeCategoryProvider recipeCategoryProvider)
        {
            _recipeCategoryProvider = recipeCategoryProvider;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
             var model = _recipeCategoryProvider.GetCategories();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddCategoryViewModel
                {
                    NameRecipeCategory = category.NameRecipeCategory,
                    IsPublished = category.IsPublished
                };
                return View("Add", viewModel);
            }
            _recipeCategoryProvider.AddCategory(category);
            return RedirectToAction("Index");
        }
    }
}