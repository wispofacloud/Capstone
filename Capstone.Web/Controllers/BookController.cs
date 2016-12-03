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
    public class BookController : EchoController
    {
        private IBooksDAL booksDAL;
        private IReviewsDAL reviewDAL;
        private IUsersDAL usersDAL;

        public BookController(IBooksDAL booksDAL, IUsersDAL usersDAL, IReviewsDAL reviewDAL)
        {
            this.booksDAL = booksDAL;
            this.usersDAL = usersDAL;
            this.reviewDAL = reviewDAL;
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
            return View("BookDetail", );
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

        //GET: Get Submit Book Review View
        public ActionResult SubmitBookReview(int id)
        {
            BookModel book = booksDAL.GetBooksById(id);
            ReviewModel model = new ReviewModel();
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            model.UserID = user.UserID;
            model.BookID = id;
            model.Title = book.Title;
            return View("SubmitBookReview", model);
        }

        //POST: Submit Book Review
        [HttpPost]
        public ActionResult SubmitBookReview(ReviewModel post)
        {

            reviewDAL.SubmitBookReview(post);
            return RedirectToAction("ThankYou");

        }



        //Partial View Linked to Detail View
        [ChildActionOnly]
        public ActionResult RenderPartialBookReviewView(int id)
        {
            ReviewModel review = new ReviewModel();
            review = reviewDAL.GetReview(id);
            return PartialView("_PartialBookReviewView", review);
        }

    }
}