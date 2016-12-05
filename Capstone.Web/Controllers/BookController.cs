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
        private IReadingListDAL rlDAL;

        public BookController(IBooksDAL booksDAL, IUsersDAL usersDAL, IReviewsDAL reviewDAL, IReadingListDAL rlDAL)
        {
            this.booksDAL = booksDAL;
            this.usersDAL = usersDAL;
            this.reviewDAL = reviewDAL;
            this.rlDAL = rlDAL;
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
            ReadingListModel list = new ReadingListModel();            
            BookModel book = new BookModel();
            book = booksDAL.GetBooksById(bookID);
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            ReviewModel review = reviewDAL.GetReview(bookID);
            BookDetailViewModel model = new BookDetailViewModel();
            model.CurrentBook = book;
            model.CurrentReview = review;
            model.CurrentUser = user;
            if (model.CurrentUser != null)
            {
                list.UserID = user.UserID;
                list.BookID = bookID;
                model.IsBookInList = rlDAL.BookAlreadyInList(list);
            }
            return View("BookDetail", model);
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
            if(newBook.Description == null)
            {
                newBook.Description = "";
            }
            if(newBook.Setting == null)
            {
                newBook.Setting = "";
            }
            if(newBook.Genre == null)
            {
                newBook.Genre = "";
            }
            if(newBook.MainCharacter == null)
            {
                newBook.MainCharacter = "";
            }
            if (newBook.ImageLink == null)
            {
                newBook.ImageLink = "https://commons.wikimedia.org/wiki/File%3ANo_image_available.svg";
            }
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

        public ActionResult AddToReadingList(int bookID, int userID)
        {
            ReadingListModel list = new ReadingListModel();
            list.BookID = bookID;
            list.UserID = userID;
            BookModel book = new BookModel();
            book = booksDAL.GetBooksById(bookID);
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            ReviewModel review = reviewDAL.GetReview(bookID);
            BookDetailViewModel model = new BookDetailViewModel();
            model.CurrentBook = book;
            model.CurrentReview = review;
            model.CurrentUser = user;
            model.CurrentReadingList = list;
            rlDAL.AddBookToReadingList(list);
            model.IsBookInList = true;
            return View("BookDetail", model);
        }
    }
}