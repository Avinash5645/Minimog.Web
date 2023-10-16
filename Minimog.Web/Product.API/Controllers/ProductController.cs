using Product.Entity.Models;
using Product.API.Models;
using Product.Service.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace Product.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("Product/GetAllProduct")]
        public IHttpActionResult GetAllProduct()
        {
            var res = _productService.GetProducts();
            var productData = Mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductModel>>(res);
            //  var produtJson = JsonConvert.SerializeObject(productData);
            return Ok(productData);
        }
        [HttpGet]
        [Route("Product/GetProduct/{id}")]
        public IHttpActionResult GetProduct(Guid id)
        {
            var res = _productService.GetProduct(id);
            var singleProduct = Mapper.Map<ProductEntity, ProductModel>(res);
            return Ok(singleProduct);
        }
    }
}
