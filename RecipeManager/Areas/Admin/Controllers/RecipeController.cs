using BLL.Abstract;
using BLL.ViewModels;
using Newtonsoft.Json;
using PagedList;
using RecipeManager.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
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

        public ActionResult Index(int? page)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");


            var model = _recipeProvider.GetRecipes().OrderBy(i => i.Id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
            //return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id));
        }



        [HttpPost]
        public ActionResult Index(int? page, int? categoryId)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            var model = _recipeProvider.GetRecipes().OrderBy(i => i.Id);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (categoryId != null)
                //View(_productProvider.GetProducts().Where(prod => prod.CategoryId == categoryId).OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
                return View(_recipeProvider.GetRecipes().Where(recipe => recipe.RecipeCategoryId == categoryId).OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));//;
            else
                return View(_recipeProvider.GetRecipes().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));//;
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
            var validTypes = new[] { "image/jpeg", "image/pjpeg", "image/png", "image/gif" };

            if (recipe.PhotoUpload != null && !validTypes.Contains(recipe.PhotoUpload.ContentType))
            {
                ModelState.AddModelError("PhotoUpload", "Please upload either a JPG, GIF, or PNG image.");
            }

            if (!ModelState.IsValid)
            {
                IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
                categoriesList = _recipeProvider.GetSelectCategories();


                if (recipe.PhotoUpload.ContentLength > 0)
                {
                    // A file was uploaded
                    var fileName = Path.GetFileName(recipe.PhotoUpload.FileName);
                    string uploadPath = "~/Images/Recipe/Big/";
                    var path = Path.Combine(Server.MapPath(uploadPath));
                    recipe.PhotoUpload.SaveAs(path);
                    recipe.RecipeImage = uploadPath + fileName;
                }


                var viewModel = new AddRecipeViewModel
                {
                    RecipeName = recipe.RecipeName,
                    RecipeImage = recipe.RecipeImage,
                    PhotoUpload = recipe.PhotoUpload,
                    RecipeDescription = recipe.RecipeDescription,
                    CreatedAt = recipe.CreatedAt,
                    ModefiedAt = recipe.ModefiedAt,
                    CookingTime = recipe.CookingTime,
                    RecipeCategoryId = recipe.RecipeCategoryId,
                    Categories = categoriesList

                };

                return View("Add", viewModel);
            }

            if (recipe.PhotoUpload != null && recipe.PhotoUpload.ContentLength > 0)
            {
                // A file was uploaded
                var fileName = Path.GetFileName(recipe.PhotoUpload.FileName);
                string uploadPath = "~/Images/Recipe/Big/";
                var path = Path.Combine(Server.MapPath(uploadPath), fileName);
                recipe.PhotoUpload.SaveAs(path);
                recipe.RecipeImage = uploadPath + fileName;
            }
            else recipe.RecipeImage = "/Images/Recipe/Big/noimage.JPEG";
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
            ViewBag.ListMenus = _recipeProvider.GetListItemMenus();
           // ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRecipeViewModel editRecipe)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            editRecipe.Categories = categoriesList;

            var image = editRecipe.PhotoUpload;
            var imageSave = WorkWithImage.CreateImage(image, 800, 600);

            if (ModelState.IsValid)
            {
                var result = _recipeProvider.EditRecipe(editRecipe);

                if (result == 0)
                {
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить! Проверьте все ли поля указаны.");
                }
                else if (result != 0)
                {
                    if (editRecipe.RecipeImage != null && editRecipe.PhotoUpload == null)
                    {
                        _recipeProvider.EditRecipe(editRecipe);
                        return RedirectToAction("Index");/*RedirectToAction("ProductsWeight", new { id = editRecipe.Id })*/;
                    }
                    else if (/*editRecipe.PhotoUpload.ContentLength > 0*/editRecipe.PhotoUpload != null)
                    {
                        // A file was uploaded
                        var fileName = Path.GetFileName(editRecipe.PhotoUpload.FileName);
                        string uploadPath = "~/Images/Recipe/Big/";
                        var path = Path.Combine(Server.MapPath(uploadPath), fileName);
                        imageSave.Save(path, ImageFormat.Jpeg);
                        editRecipe.RecipeImage = uploadPath + fileName;
                    }
                    _recipeProvider.EditRecipe(editRecipe);
                    return RedirectToAction/*("ProductsWeight", new { id = editRecipe.Id })*/("Index");
                }
            }

            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();
            ViewBag.ListMenus = _recipeProvider.GetListItemMenus();
            //ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(editRecipe.Id);
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

        [HttpPost]
        public ContentResult DeleteRecipeMenu(int recipeId, int menuId)
        {
            string json = "";

            int rez = _recipeProvider.DeleteRecipeMenu(recipeId, menuId);

            json = JsonConvert.SerializeObject(new
            {
                rez = rez
            });
            return Content(json, "application/json");
        }

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }

        [HttpGet]
        public ActionResult ProductsWeight(int Id)
        {
            RecipesViewModel model = _recipeProvider.EditRecipeProdWeight(Id);
            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();
            ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductsWeight(RecipesViewModel editRecipe)
        {

           

            var image = editRecipe.PhotoUpload;
            var imageSave = WorkWithImage.CreateImage(image, 800, 600);

            if (ModelState.IsValid)
            {
                var result = _recipeProvider.EditRecipeProdWeight(editRecipe);

                if (result == null)
                {
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить! Проверьте все ли поля указаны.");
                }
                else if (result != null)
                {
                    if (editRecipe.RecipeImage != null && editRecipe.PhotoUpload == null)
                    {
                        _recipeProvider.EditRecipeProdWeight(editRecipe);
                        return RedirectToAction("Index");/*RedirectToAction("ProductsWeight", new { id = editRecipe.Id })*/;
                    }
                    else if (/*editRecipe.PhotoUpload.ContentLength > 0*/editRecipe.PhotoUpload != null)
                    {
                        // A file was uploaded
                        var fileName = Path.GetFileName(editRecipe.PhotoUpload.FileName);
                        string uploadPath = "~/Images/Recipe/Big/";
                        var path = Path.Combine(Server.MapPath(uploadPath), fileName);
                        imageSave.Save(path, ImageFormat.Jpeg);
                        editRecipe.RecipeImage = uploadPath + fileName;
                    }
                    _recipeProvider.EditRecipeProdWeight(editRecipe);
                    return RedirectToAction/*("ProductsWeight", new { id = editRecipe.Id })*/("Index");
                }
            }

            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();
            ViewBag.ListMenus = _recipeProvider.GetListItemMenus();
            ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(editRecipe.Id);
            return View(editRecipe);
        }



        //        if (result == null)
        //        {
        //            ModelState.AddModelError("", "Ошибка! Невозможно сохранить! Проверьте все ли поля указаны.");
        //        }
        //        else if (result != null)
        //        {

        //            _recipeProvider.EditRecipeProdWeight(editRecipe);
        //            return RedirectToAction("Index");/*RedirectToAction("ProductsWeight", new { id = editRecipe.Id })*/;
        //        }
        //    }
        //            //_recipeProvider.EditRecipeProdWeight(editRecipe);
        //            // return RedirectToAction/*("Edit", new { id = editRecipe.Id })*/("Index");
        //            ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(editRecipe.Id);
        //    ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(editRecipe.Id);
        //    return View(editRecipe);
        //}

        [HttpPost]
        public ContentResult AddAjax(EditRecipeViewModel editRecipe)
        {
            //editRecipe=_recipeProvider.EditRecipeProdWeight(editRecipe);
            int status = 1;





            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _recipeProvider.GetSelectCategories();

            editRecipe.Categories = categoriesList;

            var image = editRecipe.PhotoUpload;
            var imageSave = WorkWithImage.CreateImage(image, 800, 600);

            if (ModelState.IsValid)
            {
                var result = _recipeProvider.EditRecipe(editRecipe);

                if (result == 0)
                {
                    ModelState.AddModelError("", "Ошибка! Невозможно сохранить! Проверьте все ли поля указаны.");
                }
                else if (result != 0)
                {
                    if (editRecipe.RecipeImage != null && editRecipe.PhotoUpload == null)
                    {
                        _recipeProvider.EditRecipe(editRecipe);
                        //return RedirectToAction("Index");/*RedirectToAction("ProductsWeight", new { id = editRecipe.Id })*/;
                    }
                    else if (/*editRecipe.PhotoUpload.ContentLength > 0*/editRecipe.PhotoUpload != null)
                    {
                        // A file was uploaded
                        var fileName = Path.GetFileName(editRecipe.PhotoUpload.FileName);
                        string uploadPath = "~/Images/Recipe/Big/";
                        var path = Path.Combine(Server.MapPath(uploadPath), fileName);
                        imageSave.Save(path, ImageFormat.Jpeg);
                        editRecipe.RecipeImage = uploadPath + fileName;
                    }
                    _recipeProvider.EditRecipe(editRecipe);
                    //return RedirectToAction/*("ProductsWeight", new { id = editRecipe.Id })*/("Index");
                }
            }

            ViewBag.ListProducts = _recipeProvider.GetListItemProducts();
            ViewBag.ListMenus = _recipeProvider.GetListItemMenus();
            ViewBag.ListProductWeights = _recipeProvider.GetListWeightProducts(editRecipe.Id);
           // return View(editRecipe);




            string json = JsonConvert.SerializeObject(new
            {
                result = status,
                recipe = editRecipe,

           
            
        });
            return Content(json, "application/json");

        }

    }
}