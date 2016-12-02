using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Filters;

namespace Capstone.Web.Controllers
{
    public class MyEchoBooksController : UsersController
    {
        private readonly IReadingListDAL readingListDAL;
        public MyEchoBooksController(IReadingListDAL readingListDAL, IUsersDAL usersDAL) : base(usersDAL)
        {
            this.readingListDAL = readingListDAL;
        }

        // GET: MyEchoBooks
        [AuthorizationFilter]
        public ActionResult Index()
        {
            return View();
        }


    }
}