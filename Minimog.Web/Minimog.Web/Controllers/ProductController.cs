using Minimog.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minimog.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var res = _productService.GetProducts();
            return View(res);
        }
        public ActionResult Detail(Guid id )
        {
            var res = _productService.GetProduct(id);
            return View(res);
        }
    }
}