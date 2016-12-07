using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.Web.Models;
using System.Collections.Generic;
using Capstone.Web.DAL;



namespace Capstone.Web.Tests.DALTests
{
    [TestClass]
    public class ForumSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        int threadId = -1;
        int categoryID = 1;
        int postID = -1;
        int userId = -1;
        

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from posts; Delete from threads", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("Insert into users values(1, 'joe', 'password', 'salt'); Select cast(Scope_Identity() as int)", conn);
                userId = (int)cmd1.ExecuteScalar();
                SqlCommand cmd2 = new SqlCommand("Insert into threads values(1, 1,'The awesome threadName', '2016-12-07 00:00:00.000'); Select cast(Scope_Identity() as int)", conn);
                threadId = (int)cmd2.ExecuteScalar();
                SqlCommand cmd3 = new SqlCommand($"Insert into posts values({threadId}, 1, 'This postBody is awesome', '2016-12-07 00:00:00.000'); Select cast(Scope_Identity() as int)", conn);
                postID = (int)cmd3.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestGetAllPostsByThreadID()
        {
            ForumSqlDAL forumSqlDal = new ForumSqlDAL();
            List<PostModel> threadByThreadID = forumSqlDal.GetAllPosts(threadId);

            Assert.IsNotNull(threadByThreadID);
            Assert.AreEqual(1, threadByThreadID.Count);
        }

        [TestMethod]
        public void TestGetThreadsByCategory_ByCategoryID()
        {
            ForumSqlDAL forumSqlDal = new ForumSqlDAL();
            List<ThreadModel> threadByCategoryID = forumSqlDal.GetThreadsByCategory(categoryID);

            Assert.IsNotNull(threadByCategoryID);
            Assert.AreEqual(1, threadByCategoryID.Count);
        }

        [TestMethod]
        public void TestGetThreadByThreadID()
        {
            ForumSqlDAL forumSqlDal = new ForumSqlDAL();
            ThreadModel thread = new ThreadModel();
            thread = forumSqlDal.GetThreadByThreadID(threadId);

            Assert.IsNotNull(thread);
            Assert.AreEqual(threadId, thread.ThreadID);
            Assert.AreEqual(1, thread.CategoryID);
            Assert.AreEqual("The awesome threadName", thread.ThreadName);
            Assert.AreEqual("12/7/2016 12:00:00 AM", thread.ThreadDate.ToString());

        }

        [TestMethod]
        public void TestSubmitPost()
        {
            ForumSqlDAL dal = new ForumSqlDAL();
            PostResultsViewModel model = new PostResultsViewModel();
            PostModel newPost = new PostModel();
            model.NewPost = newPost;
            model.NewPost.ThreadID = threadId;
            model.NewPost.UserID = userId;
            model.NewPost.ThreadName = "The awesome threadName";
            model.NewPost.PostBody = "This is the postBody";

            bool isSubmitted = dal.SubmitPost(model);

            Assert.IsTrue(isSubmitted);

        }

        [TestMethod]
        public void TestSubmitThread()
        {
            ForumSqlDAL dal = new ForumSqlDAL();
            ThreadModel model = new ThreadModel();
            model.UserID = userId;
            model.CategoryID = 2;
            model.ThreadName = "The awesome threadName";

            bool isSubmitted = dal.SubmitThread(model);

            Assert.IsTrue(isSubmitted);

        }

        [TestMethod]
        public void TestGetAllCategories()
        {
            ForumSqlDAL dal = new ForumSqlDAL();
            List<CategoriesModel> model = new List<CategoriesModel>();
            model = dal.GetAllCategories();


            Assert.AreEqual(3, model[2].CategoryID);
            Assert.AreEqual("Fan Fiction", model[2].CategoryName);

        }





    }
}
