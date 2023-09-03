using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minimog.Web.Models;
using Minimog.Web.Repository;

namespace Minimog.Web.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
       public BoolRespose SaveUser(User user)  
        {
            var res = _userRepository.SaveUser(user);
            return res;
        }
    }
}