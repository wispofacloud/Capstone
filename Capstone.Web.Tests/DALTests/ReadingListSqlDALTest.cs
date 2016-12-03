using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using Capstone.Web.Models;
using System.Collections.Generic;


namespace Capstone.Web.Tests.DALTests
{
    [TestClass]
    public class ReadingListSqlDALTest
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
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

  
        [TestMethod]
        public void TestAddBookToReadingList_ByBookID()
        {
        }

        [TestMethod]
        public void TestChangeBookToHasRead()
        {
        }

        [TestMethod]
        public void TestGetReadingList()
        {

        }

    }
}
