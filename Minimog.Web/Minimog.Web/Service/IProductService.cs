using Minimog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimog.Web.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(Guid id);
    }
}
