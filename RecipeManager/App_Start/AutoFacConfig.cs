using Autofac;
using Autofac.Integration.Mvc;
using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeManager
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new DataModel("ConnShopDb"));
            var conteiner = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(conteiner));
        }
    }
}