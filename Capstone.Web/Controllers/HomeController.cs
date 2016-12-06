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

        //Get: Get New Author List
        public ActionResult RenderPartialNewAuthorList()
        {
            List<String> model = new List<String>();
            model = booksDAL.GetNewAuthorList();
            return View("_PartialNewAuthorList", model);
        }
    }
}