using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ForumController : EchoController
    {
        private IForumDAL forumDAL;
        // GET: Forum
        public ActionResult ViewPosts(int threadID)
        {
            PostResultsViewModel model = new PostResultsViewModel();

            return View("ViewPosts", model);
        }
    }
}