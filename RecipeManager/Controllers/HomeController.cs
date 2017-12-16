using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeProvider _recipeProvider;

        public HomeController(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }

        public ActionResult Index()
        {
            var model = _recipeProvider.GetRecipes();
            var r = new Random();
            
            var rand = r.Next(0, model.Count());
            RecipesViewModel randRecipe = model./*Where(m => m.Id == 53).FirstOrDefault()*/ElementAt(rand);
           // var c = _recipeProvider.GetRecipeProdInfo(rand).CaloricValue;
           GetRecipeProdItemInfoViewModel info= _recipeProvider.GetRecipeProdInfo(randRecipe.Id);
            ViewBag.ProdInfo = info;
            return View(randRecipe);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
    }
}