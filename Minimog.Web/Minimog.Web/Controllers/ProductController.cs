using Minimog.Web.Models;
using Minimog.Web.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Minimog.Web.Controllers
{
    public class ProductController : Controller
    {
        Uri url = new Uri(ConfigurationManager.AppSettings["Baseurl"]);
        HttpClient Client = new HttpClient();

        //private readonly IProductService _productService;
        //public ProductController(IProductService productService)
        //{
        //    _productService = productService;
        //}

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            HttpResponseMessage res = Client.GetAsync(url + "Product/GetAllProduct").Result;
            var prodData = res.Content.ReadAsStringAsync().Result;
            IEnumerable<Product> productJson = JsonConvert.DeserializeObject<List<Product>>(prodData);
            return View(productJson);
           // var res = _productService.GetProducts();
            //return View(res);
        }
        public ActionResult Detail(Guid id)
        {
            HttpResponseMessage res = Client.GetAsync(url + "Product/GetProduct/"+id).Result;
            var prodData = res.Content.ReadAsStringAsync().Result;
            Product productJson = JsonConvert.DeserializeObject<Product>(prodData);
            return View(productJson);
            //var res = _productService.GetProduct(id);
            //return View(res);
           // return View();
        }
    }
}