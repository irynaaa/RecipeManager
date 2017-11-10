using Autofac;
using BLL.Abstract;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
using BLL.Services;
using BLL.Services.Identity;
using DAL.Entities.Identity;


namespace BLL.Concrete
{
    public class DataModel: Module
    {
        private string _connStr;
        private IAppBuilder _app;
        public DataModel(string connString, IAppBuilder app)
        {
            _connStr = connString;
            _app = app;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //my
            //builder.Register(c => new EFContext(this._connStr))
            //    .As<IEFContext>().InstancePerRequest();
            //builder.Register(ctx =>
            //{
            //    var context = (EFContext)ctx.Resolve<IEFContext>();
            //    return context;
            //}).AsSelf().InstancePerDependency();

            ///

            builder.Register(c => new EFContext(this._connStr)).As<IEFContext>().InstancePerRequest();
            builder.Register(ctx =>
            {
                var context = (EFContext)ctx.Resolve<IEFContext>();
                return context;
            }).AsSelf().InstancePerDependency();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<AppUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => _app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<AccountProvider>().AsSelf().InstancePerRequest();
            /////////


            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>().AsSelf().InstancePerRequest();


            builder.RegisterType<ProductProvider>()
               .As<IProductProvider>().AsSelf().InstancePerRequest();
            

            builder.RegisterType<RecipeRepository>()
               .As<IRecipeRepository>().AsSelf().InstancePerRequest();

            builder.RegisterType<RecipeProvider>()
               .As<IRecipeProvider>().AsSelf().InstancePerRequest();

            builder.RegisterType<MenuRepository>()
              .As<IMenuRepository>().AsSelf().InstancePerRequest();

            builder.RegisterType<MenuProvider>()
               .As<IMenuProvider>().AsSelf().InstancePerRequest();

            builder.RegisterType<RecipeProdRecordRepository>()
              .As<IRecipeProdRecordRepository>().AsSelf().InstancePerRequest();

            builder.RegisterType<RecipeProdRecordProvider>()
               .As<IRecipeProdRecordProvider>().AsSelf().InstancePerRequest();

            builder.RegisterType<MenuRecipeRecordRepository>()
              .As<IMenuRecipeRecordRepository>().AsSelf().InstancePerRequest();

            builder.RegisterType<MenuRecipeRecordProvider>()
               .As<IMenuRecipeRecordProvider>().AsSelf().InstancePerRequest();

            builder.RegisterType<RecipeCategoryRepository>()
             .As<IRecipeCategoryRepository>().AsSelf().InstancePerRequest();

            builder.RegisterType<RecipeCategoryProvider>()
               .As<IRecipeCategoryProvider>().AsSelf().InstancePerRequest();

           

            //builder.RegisterType<UserRepository>()
            //  .As<IUserRepository>().InstancePerRequest();

            //builder.RegisterType<AccountProvider>()
            //  .As<IAccountProvider>().InstancePerRequest();

            //builder.RegisterType<UserProvider>()
            // .As<IUserProvider>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
