using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minimog.Web.Data;
using Minimog.Web.Models;

namespace Minimog.Web.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IProductDataFactory _productDataFactory;
        public MinimogDbDataDataContext _minimogDbDataDataContext;
        public UserRepository(IProductDataFactory productDataFactory)
        {
            _productDataFactory = productDataFactory;
            _minimogDbDataDataContext = _productDataFactory.MinimogDbDataDataContext();

        }
        public BoolRespose SaveUser(User User)
        {
            var response= new BoolRespose();
            var results = _minimogDbDataDataContext.procSaveUser(User.UserName, User.Email, User.Password);
            var result = results.SingleOrDefault();
            if (result != null)
            {
                response.IsValid = result.IsValid.GetValueOrDefault();
                response.Message = result.Message;
            }
            return response;
        }
    }
}