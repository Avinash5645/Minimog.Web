using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimog.Web.Models;

namespace Minimog.Web.Service
{
    public interface IUserService
    {
        BoolRespose SaveUser(User user);
        BoolRespose LoginCheck(User user);    
    }
}
