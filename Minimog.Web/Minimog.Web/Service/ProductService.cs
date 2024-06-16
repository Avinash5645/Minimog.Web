using Minimog.Web.Models;
using Minimog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minimog.Web.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts(string search)
        {
            var res=_productRepository.GetProducts(search);
            return res;
        }
        public Product GetProduct(Guid id)
        {
            var res = _productRepository.GetProduct( id);
            return res;
        }
	}
}