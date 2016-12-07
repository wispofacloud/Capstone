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
        private IUsersDAL usersDAL;

        public ForumController(IForumDAL forumDAL, IUsersDAL usersDAL)
        {
            this.forumDAL = forumDAL;
            this.usersDAL = usersDAL;
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
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            PostModel newPost = new PostModel();
            model.NewPost = newPost;
            model.NewPost.UserID = user.UserID;
            model.NewPost.ThreadID = thread.ThreadID;
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
        //get
        public ActionResult AddAThread(int categoryID)
        {
            ThreadModel model = new ThreadModel();
            model.CategoryID = categoryID;
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            model.UserID = user.UserID;

            return View("SubmitThread", model);
        }

        [HttpPost]
        public ActionResult AddAThread(ThreadModel model)
        {
            forumDAL.SubmitThread(model);
            List<ThreadModel> AllThreads = new List<ThreadModel>();
            AllThreads = forumDAL.GetThreadsByCategory(model.CategoryID);
            return View("ViewThreads", AllThreads);
        }

        //get
        public ActionResult AddAPost(int threadID)
        {
            PostModel model = new PostModel();
            model.ThreadID = threadID;
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            model.UserID = user.UserID;
            return View("SubmitPost", model);
        }

        [HttpPost]
        public ActionResult AddAPost(PostResultsViewModel model)
        {
            forumDAL.SubmitPost(model);
            List<PostModel> AllPosts = new List<PostModel>();
            AllPosts = forumDAL.GetAllPosts(model.SelectedThread.ThreadID);
            model.AllPostsInThread = AllPosts;
            UserModel user = usersDAL.GetUser(base.CurrentUser);
            model.NewPost.UserID = user.UserID;
            model.NewPost.Username = user.Username;
            model.NewPost.PostBody = "";
            
            return View("ViewPosts", model);
        }

    }
}