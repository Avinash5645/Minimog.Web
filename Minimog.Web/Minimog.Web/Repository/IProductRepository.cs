using Minimog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimog.Web.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(Guid id);
    }
}
