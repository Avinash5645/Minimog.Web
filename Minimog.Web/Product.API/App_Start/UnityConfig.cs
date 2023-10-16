using AutoMapper;
using Product.API.Models;
using Product.Data.DBML;
using Product.Data.ProductRepository;
using Product.Entity.Models;
using Product.Service.ProductService;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Product.API
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
           // container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProductService, ProductService>();
            // container.RegisterType<IUserService, UserService>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductEntity, ProductModel>();
            });

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}