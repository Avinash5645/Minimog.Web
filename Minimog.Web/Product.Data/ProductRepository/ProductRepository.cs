using Newtonsoft.Json;
using Product.Data.DBML;
using Product.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDataFactory _productDataFactory;
        public MinimogDbDataDataContext _minimogDbDataDataContext;
        public ProductRepository(IProductDataFactory productDataFactory)
        {
            _productDataFactory = productDataFactory;
            _minimogDbDataDataContext = _productDataFactory.MinimogDbDataDataContext();

        }
        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        public List<ProductEntity> GetProducts()
        {
            var products = new List<ProductEntity>();
            var resproducts = _minimogDbDataDataContext.procGetProductDataAsJsonResult_20230806();
            var jsonResult = resproducts.FirstOrDefault();
            products = JsonConvert.DeserializeObject<List<ProductEntity>>(jsonResult?.JsonResult);
            return products;
        }
        /// <summary>
        /// get productdetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductEntity GetProduct(Guid id)
        {
            var products = new List<ProductEntity>();
            var resproducts = _minimogDbDataDataContext.procGetProductByIdAsJson_20230806(id);
            var jsonResult = resproducts.FirstOrDefault();
            products = JsonConvert.DeserializeObject<List<ProductEntity>>(jsonResult?.JsonResult);
            return products.FirstOrDefault();
        }
    }
}
