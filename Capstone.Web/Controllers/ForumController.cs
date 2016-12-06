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

        public ForumController(IForumDAL forumDAL)
        {
            this.forumDAL = forumDAL;
        }
        // GET: Forum
        
       
        public ActionResult ViewPosts(int threadID)
        {
            List<PostModel> list = new List<PostModel>();
            PostResultsViewModel model = new PostResultsViewModel();
            ThreadModel thread = forumDAL.GetThreadByThreadID(threadID);
            model.SelectedThread = thread;
            list = forumDAL.GetAllPosts(threadID);
            model.AllPostsInThread = list;
            return View("ViewPosts", model);
        }

        public ActionResult ViewThreads(int categoryID)
        {
            List<ThreadModel> AllThreads = new List<ThreadModel>();
            AllThreads = forumDAL.GetThreadsByCategory(categoryID);
            return View("ViewThreads", AllThreads);
        }

        public ActionResult ViewCategories()
        {
            List<CategoriesModel> AllCategories = new List<CategoriesModel>();
            AllCategories = forumDAL.GetAllCategories();
            return View("ViewCategories",AllCategories);
        }
    }
}