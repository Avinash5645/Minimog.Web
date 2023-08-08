using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimog.Web.Data
{
    public interface IProductDataFactory
    {
        MinimogDbDataDataContext MinimogDbDataDataContext();
    }
}
