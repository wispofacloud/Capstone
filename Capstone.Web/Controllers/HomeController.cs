using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBooksDAL booksDAL;

        public HomeController(IBooksDAL booksDAL)
        {
            this.booksDAL = booksDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        //Get: Get Partial New Author List
        public ActionResult PartialNewAuthorList()
        {
            List<String> model = booksDAL.GetNewAuthorList();
            return PartialView("_PartialNewAuthorList", model);
        }
        //Get: Get New Author List
        public ActionResult NewAuthorList()
        {
            List<String> model = booksDAL.GetNewAuthorList();
            return View("NewAuthors", model);
        }
    }
}