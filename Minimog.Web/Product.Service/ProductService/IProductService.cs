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
        List<ProductEntity> GetProducts();
        ProductEntity GetProduct(Guid id);
    }
}
