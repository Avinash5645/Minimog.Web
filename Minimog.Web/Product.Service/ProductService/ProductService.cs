using Product.Data.ProductRepository;
using Product.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductEntity> GetProducts()
        {
            var res = _productRepository.GetProducts();
            return res;
        }
        public ProductEntity GetProduct(Guid id)
        {
            var res = _productRepository.GetProduct(id);
            return res;
        }
    }
}
