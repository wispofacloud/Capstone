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
        public ActionResult SearchResults(SearchResultModel model)
        {
            ViewBag.SearchCriteria = searchCriteria;
            return View("SearchResults", model);
        }

        //GET: Detail of chosen book
        public ActionResult BookDetail(int bookID)
        {
            BookModel model = new BookModel();
            return View("BookDetail", model);
        }
        //GET: Book Search
        public List<SelectListItem> searchCriteria = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Title" },
            new SelectListItem() {Text = "Author" },
            new SelectListItem() {Text = "Setting" },
            new SelectListItem() {Text = "Character" },
            new SelectListItem() {Text = "Keyword" }

        };

      
    }
}