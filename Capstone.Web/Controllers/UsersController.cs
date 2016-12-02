using Capstone.Web.Crypto;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class UsersController : EchoController
    {
        private readonly IUsersDAL usersDAL;
        private const string UsernameKey = "UsernameKey";
        public UsersController(IUsersDAL usersDAL)
        {
            this.usersDAL = usersDAL;
        }


        [HttpGet]
        public ActionResult NewUser()
        {

            if (IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var model = new NewUserViewModel();
                return View("NewUser", model);
            }
        }

        [HttpPost]
        public ActionResult NewUser(NewUserViewModel model)
        {
            if (IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var currentUser = usersDAL.GetUser(model.Username);
                if(currentUser != null)
                {
                    ModelState.AddModelError("Username", "This username is unavailable.");
                    return View("newUser", model);
                }
                var hashProvider = new HashProvider();
                var hashedPassword = hashProvider.HashPassword(model.Password);
                var salt = hashProvider.SaltValue;

                var newUser = new UserModel
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    Salt = salt
                };

                usersDAL.RegisterNewUser(newUser);

                LogUserIn(model.Username);
                return RedirectToAction("Index", "Home");
            
            }
            return View("NewUser", model);
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = usersDAL.GetUser(model.Username);

                if (user == null)
                {
                    ModelState.AddModelError("Username", "The username or password is invalid.");
                    return View("Login", model);
                }

                var hashProvider = new HashProvider();
                if(!hashProvider.VerifyPasswordMatch(user.Password, model.Password, user.Salt))
                {
                    ModelState.AddModelError("Username", "The username or password is invalid.");
                    return View("Login", model);
                }

                LogUserIn(user.Username);

                return RedirectToAction("Index", "Home");

            }
            return View("Login", model);
        }

        public ActionResult Logout()
        {
            LogUserOut();
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult GetAuthenticatedUser()
        {
            UserModel model = null;

            if (IsAuthenticated)
            {
                model = usersDAL.GetUser(CurrentUser);
            }

            return PartialView("_PartialLoginLogoutView", model);
        }

    }
}