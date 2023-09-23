using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Minimog.Web.Data
{
    public class ProductDataFactory: IProductDataFactory
    {
        static MappingSource _sharedMappingSource = new AttributeMappingSource();
        string _connectionString;
        public MinimogDbDataDataContext MinimogDbDataDataContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SgMinimogConnectionString"].ConnectionString;
            return new MinimogDbDataDataContext(_connectionString, _sharedMappingSource);
        }
    }
}