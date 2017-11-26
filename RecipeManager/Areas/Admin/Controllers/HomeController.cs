using BLL.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {

        // GET: Admin/Home
        public ActionResult Index()
        {
           // UserViewModel uwm = new UserViewModel();
            return View();
        }

    }
}