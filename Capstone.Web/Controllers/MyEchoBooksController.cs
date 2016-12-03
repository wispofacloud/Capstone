using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Filters;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class MyEchoBooksController : EchoController
    {
        private readonly IReadingListDAL readingListDAL;
        private readonly IUsersDAL usersDAL;
        public MyEchoBooksController(IReadingListDAL readingListDAL, IUsersDAL usersDAL)
        {
            this.readingListDAL = readingListDAL;
            this.usersDAL = usersDAL;
        }

        [AuthorizationFilter]
        public ActionResult ReadingList()
        {
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            List<ReadingListModel> readingList = readingListDAL.GetReadingList(user.UserID);
            MyEchoBooksViewModel model = new MyEchoBooksViewModel();
            model.ReadingList = readingList;
            model.CurrentUser = user;
            return View("ReadingList", model);
        }

        [AuthorizationFilter]
        public ActionResult ChangeToRead(ReadingListModel model)
        {
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            List<ReadingListModel> readingList = readingListDAL.GetReadingList(user.UserID);
            MyEchoBooksViewModel viewModel = new MyEchoBooksViewModel();
            viewModel.ReadingList = readingList;
            viewModel.CurrentUser = user;
            readingListDAL.ChangeBookToHasRead(model);
            return View("ReadingList", viewModel);
        }
    } }
