using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minimog.Web.Models;
using Minimog.Web.Service;

namespace Minimog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// registration
        /// </summary>
        /// <returns></returns>
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RegistrationData( User UserData)
        {
            var response = _userService.SaveUser(UserData);
                // In a real-world scenario, you would process the registration data
                // and return an appropriate response.
                //if (ModelState.IsValid)
                //{
                //    // Assuming you're using some sort of user service or database context
                //    // to store the registration data.
                //    // userService.Register(userData);

                //    var response = new { Message = "Registration successful." };
                //    return Json(response);
                //}
                //else
                //{
                //    var errors = ModelState.Values
                //        .SelectMany(v => v.Errors)
                //        .Select(e => e.ErrorMessage);

                //    var response = new { Errors = errors };
                //    return Json(response, JsonRequestBehavior.AllowGet);
                //}
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}