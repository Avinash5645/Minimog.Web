using Product.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.ProductService
{
    public interface IProductService
    {
        List<ProductEntity> GetProducts(string search);
        ProductEntity GetProduct(Guid id);
    }
}
