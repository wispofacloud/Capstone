using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult SearchResults()
        {
            List<BookModel> listBooks = new List<BookModel>();
            return View("SearchResults", listBooks);
        }

        //GET: Detail of chosen book
        public ActionResult BookDetail(int bookID)
        {
            BookModel model = new BookModel();
            return View("BookDetail", model);
        }
    }
}