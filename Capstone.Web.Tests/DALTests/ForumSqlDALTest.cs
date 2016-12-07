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

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
               // SqlCommand cmd = new SqlCommand(, conn);
              //  cmd.ExecuteNonQuery();
               // SqlCommand cmd2 = new SqlCommand(, conn);
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
        }
        [TestMethod]
        public void TestGetThreadsByCategory_ByCategoryID()
        {
        }
        [TestMethod]
        public void TestGetThreadByThreadID()
        {
        }
        [TestMethod]
        public void TestSubmitPost()
        {
        }
        [TestMethod]
        public void TestSubmitReview()
        {
        }
        [TestMethod]
        public void TestGetAllCategories()
        {
        }





    }
}
