using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuProvider _menuProvider;
        public MenuController(IMenuProvider menuProvider)
        {
            _menuProvider = menuProvider;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            var model = _menuProvider.GetMenus();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddMenuViewModel menu)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddMenuViewModel
                {
                    MenuName = menu.MenuName
                };
                return View("Add", viewModel);
            }
            _menuProvider.AddMenu(menu);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = _menuProvider.GetMenuDetales(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(MenusViewModel model)
        {
            _menuProvider.RemoveMenu(model.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _menuProvider.GetMenuDetales(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _menuProvider.EditMenu(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditMenuViewModel editMenu)
        {
            if (ModelState.IsValid)
            {
                int result = _menuProvider.EditMenu(editMenu);
                if (result == 0)
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить!");
                else if (result != 0)
                    return RedirectToAction("Index");
            }
            return View(editMenu);
        }
    }
}