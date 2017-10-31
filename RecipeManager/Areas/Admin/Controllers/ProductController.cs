using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductProvider _productProvider;
        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            var model = _productProvider.GetProducts();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddProductViewModel
                {
                ProductName = product.ProductName,
                CaloricValue=product.CaloricValue,
                Fat=product.Fat,
                Proteins=product.Proteins,
                Carbohydrates=product.Carbohydrates
                };
                return View("Add", viewModel);
            }
            _productProvider.AddProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = _productProvider.GetProductDetales(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(CategoryItemViewModel model)
        {
            _productProvider.RemoveProduct(model.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _productProvider.GetProductDetales(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productProvider.EditProduct(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProductViewModel editProduct)
        {
            if (ModelState.IsValid)
            {
                int result = _productProvider.EditProduct(editProduct);
                if (result == 0)
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить!");
                else if (result != 0)
                    return RedirectToAction("Index");
            }
            return View(editProduct);
        }
    }
}