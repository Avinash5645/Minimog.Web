using Minimog.Web.Data;
using Minimog.Web.Repository;
using Minimog.Web.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Minimog.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductDataFactory, ProductDataFactory>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IUserService, UserService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}