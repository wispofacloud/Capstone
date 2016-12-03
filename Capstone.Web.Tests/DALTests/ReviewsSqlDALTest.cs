using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using Capstone.Web.Models;
using System.Collections.Generic;
using Capstone.Web.DAL;

namespace Capstone.Web.Tests.DALTests
{
    [TestClass]
    public class ReviewsSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;
        int reviewID = -1;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("Delete from reviews", conn);
                cm.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Insert into reviews values(1, 1, 'Lily the Cat is a Great Book! I loved Detective Brandons stern demeanor but also how he melted when he met Lily. Best book evah!'); Select cast(Scope_Identity() as int);", conn);
                reviewID = (int)cmd2.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestGetReviewByBookID()
        {
            ReviewsSqlDAL dal = new ReviewsSqlDAL();
            ReviewModel model = dal.GetReview(1);

            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.BookID);
        }
    }
}
