using Minimog.Web.Data;
using Minimog.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minimog.Web.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly IProductDataFactory _productDataFactory;
        public  MinimogDbDataDataContext _minimogDbDataDataContext;
        public ProductRepository(IProductDataFactory productDataFactory)
        {
            _productDataFactory = productDataFactory;
            _minimogDbDataDataContext = _productDataFactory.MinimogDbDataDataContext();

        }
        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {   var products = new List<Product>();
            var resproducts = _minimogDbDataDataContext.procGetProductDataAsJsonResult_20230806();
            var jsonResult = resproducts.FirstOrDefault();
            products = JsonConvert.DeserializeObject<List<Product>>(jsonResult?.JsonResult);
            return products;
        }
        /// <summary>
        /// get productdetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(Guid id)
        {
            var products = new List<Product>();
            var resproducts = _minimogDbDataDataContext.procGetProductByIdAsJson_20230806(id);
            var jsonResult = resproducts.FirstOrDefault();
            products = JsonConvert.DeserializeObject<List<Product>>(jsonResult?.JsonResult);
            return products.FirstOrDefault();
        }
    }
}