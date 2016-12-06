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
    public class UsersSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;
        int userID = -1;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("Delete from posts; Delete from threads; Delete from readingList; Delete from reviews; Delete from users", conn);
                cm.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Insert into users values(1, 'username', 'Happy10th!', 'rht23o451309');Select cast(Scope_Identity() as int)", conn);
                userID = (int)cmd2.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestGetUser_ByUsername()
        {

            UsersSqlDAL dal = new UsersSqlDAL();
            UserModel user = dal.GetUser("username");

            Assert.IsNotNull(user);
            Assert.AreEqual(true, user.IsAdmin);
            Assert.AreEqual("rht23o451309", user.Salt);
            Assert.AreEqual(userID, user.UserID);
        }

        [TestMethod]
        public void TestGetUser_ByUsernameAndPassword()
        {
            UsersSqlDAL dal = new UsersSqlDAL();
            UserModel user = dal.GetUser("username", "Happy10th!");

            Assert.IsNotNull(user);
            Assert.AreEqual(userID, user.UserID);
            Assert.AreEqual(true, user.IsAdmin);
        }

        [TestMethod]
        public void TestRegisterNewUser_IsTrue()
        {
            UsersSqlDAL dal = new UsersSqlDAL();
            UserModel user = new UserModel();
            
            user.IsAdmin = false;
            user.Username = "Sekdog";
            user.Password = "crackers5!";
            user.Salt = "vqporeit5u20";

            bool registered = dal.RegisterNewUser(user);

            Assert.IsTrue(registered);
       }

    }
}
