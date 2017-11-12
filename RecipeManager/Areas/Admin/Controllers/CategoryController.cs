using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
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

        public ActionResult Remove(int id)
        {
            var model = _recipeCategoryProvider.GetCategoryDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(CategoryItemViewModel model)
        {
            _recipeCategoryProvider.RemoveCategory(model.Id);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var model = _recipeCategoryProvider.GetCategoryDetails(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _recipeCategoryProvider.EditRecipeCategory(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRecipeCategoryViewModel editCategory)
        {
            if (ModelState.IsValid)
            {
                int result = _recipeCategoryProvider.EditRecipeCategory(editCategory);
                if (result == 0)
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить!");
                else if (result != 0)
                    return RedirectToAction("Index");
            }
            return View(editCategory);
        }
    }
}