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
    public class ReadingListSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;
        int bookUser = -1; 

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from readingList; Delete from users; Delete from books", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Insert into readingList values(5, 7, 0); Select cast(Scope_Identity() as int);", conn);
                bookUser = (int)cmd2.ExecuteScalar();
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestAddBookToReadingList()
        {
            ReadingListSqlDAL dal = new ReadingListSqlDAL();
            ReadingListModel readingList = new ReadingListModel();

            readingList.BookID = 1;
            readingList.UserID = 1;
            

            bool addBook = dal.AddBookToReadingList(readingList);
            Assert.IsTrue(addBook);

        }

        [TestMethod]
        public void TestChangeBookToHasRead()
        {
            ReadingListSqlDAL dal = new ReadingListSqlDAL();
            ReadingListModel readingList = new ReadingListModel();

            readingList.BookID = 1;
            readingList.UserID = 1;
            readingList.HasRead = false;

            bool hasRead = dal.AddBookToReadingList(readingList);
            Assert.IsTrue(hasRead);

        }

        [TestMethod]
        public void TestGetReadingList()
        {
            ReadingListSqlDAL dal = new ReadingListSqlDAL();
            List<ReadingListModel> readingList = dal.GetReadingList(1);

            Assert.IsNotNull(readingList);
            Assert.AreEqual(1, readingList.Count);

        }

        [TestMethod]
        public void TestBookAlreadyInList()
        {
            ReadingListSqlDAL dal = new ReadingListSqlDAL();
            ReadingListModel readingList = new ReadingListModel();

            readingList.BookID = 1;
            readingList.UserID = 1;

            bool bookAlreadyInList = dal.BookAlreadyInList(readingList);
            Assert.IsTrue(bookAlreadyInList);

        }

    }
}
