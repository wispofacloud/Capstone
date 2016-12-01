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
    public class UsersController : Controller
    {
        private readonly IUsersDAL usersDAL;
        private const string UsernameKey = "UsernameKey";
        public UsersController(IUsersDAL usersDAL)
        {
            this.usersDAL = usersDAL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public bool IsAuthenticated
        {
            get
            {
                return Session[UsernameKey] != null;
            }
        }

        [HttpGet]
        [Route("users/new")]
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

        public void LogUserIn(string username)
        {
            Session[UsernameKey] = username;
        }

        public void LogUserOut()
        {
            Session.Abandon();
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

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                //Check to see if user cookie exists, if not create it
                if (Session[UsernameKey] != null)
                {
                    username = (string)Session[UsernameKey];
                }

                return username;
            }
        }
    }
}