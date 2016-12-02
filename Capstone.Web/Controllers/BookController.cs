using Capstone.Web.DAL;
using Capstone.Web.Filters;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class BookController : UsersController
    {
        private IBooksDAL booksDAL;

        public BookController(IBooksDAL booksDAL, IUsersDAL usersDAL) : base(usersDAL)
        {
            this.booksDAL = booksDAL;
        }

        //GET: Book Search
        public List<SelectListItem> searchCriteria = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Title" },
            new SelectListItem() {Text = "Author" },
            new SelectListItem() {Text = "Setting" },
            new SelectListItem() {Text = "Character" },
            //new SelectListItem() {Text = "Keyword" }

        };

        // GET: Book
        public ActionResult SearchResults(SearchResultModel model)
        {
            var value = model.SearchValue;
            var type = model.SearchType;
            model.Results = booksDAL.GetBooks(value, type);
            ViewBag.SearchCriteria = searchCriteria;
            return View("SearchResults", model);
        }

        //GET: Detail of chosen book
        public ActionResult BookDetail(int bookID)
        {
            BookModel book = new BookModel();
            book = booksDAL.GetBooksById(bookID);
            return View("BookDetail", book);
        }

        //GET: Get Add New Book View
        [AuthorizationFilter]
        public ActionResult AddNewBook()
        {
            return View("AddNewBook");
        }
        //POST: Add New Book
        [AuthorizationFilter]
        [HttpPost]
        public ActionResult AddNewBook(BookModel newBook)
        {
            booksDAL.AddNewBook(newBook);
            return RedirectToAction("ThankYou");

        }
        public ActionResult ThankYou()
        {
            return View("ThankYou");
        }

        //Get: Get New Book List
        public ActionResult NewBookList()
        {
            List<BookModel> model = new List<BookModel>();
            model = booksDAL.GetNewBookList();
            return View("NewBookList", model);
        }

    }
}