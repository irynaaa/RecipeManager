using Autofac;
using BLL.Abstract;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class DataModel: Module
    {
        private string _connStr;
        public DataModel(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this._connStr))
                .As<IEFContext>().InstancePerRequest();

            

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>().InstancePerRequest();

            builder.RegisterType<ProductProvider>()
               .As<IProductProvider>().InstancePerRequest();

            builder.RegisterType<RecipeRepository>()
               .As<IRecipeRepository>().InstancePerRequest();

            builder.RegisterType<RecipeProvider>()
               .As<IRecipeProvider>().InstancePerRequest();

            builder.RegisterType<MenuRepository>()
              .As<IMenuRepository>().InstancePerRequest();

            builder.RegisterType<MenuProvider>()
               .As<IMenuProvider>().InstancePerRequest();

            builder.RegisterType<RecipeProdRecordRepository>()
              .As<IRecipeProdRecordRepository>().InstancePerRequest();

            builder.RegisterType<RecipeProdRecordProvider>()
               .As<IRecipeProdRecordProvider>().InstancePerRequest();

            builder.RegisterType<MenuRecipeRecordRepository>()
              .As<IMenuRecipeRecordRepository>().InstancePerRequest();

            builder.RegisterType<MenuRecipeRecordProvider>()
               .As<IMenuRecipeRecordProvider>().InstancePerRequest();

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
