using Product.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.ProductRepository
{
    public interface IProductRepository
    {
        List<ProductEntity> GetProducts();
        ProductEntity GetProduct(Guid id);
    }
}
