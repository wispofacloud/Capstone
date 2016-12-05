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
        //int bookUser = -1; 

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from readingList;", conn);
                //Sekhar also had  Delete from users; Delete from books
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Insert into readingList values(1, 1, 0);", conn);
                //there is no identity column in the reading list so no need for Select cast(Scope_Identity() as int);
                cmd2.ExecuteScalar();
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

            readingList.BookID = 2;
            readingList.UserID = 2;
            

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

            bool hasRead = dal.ChangeBookToHasRead(readingList);
            Assert.IsTrue(hasRead);
            List<ReadingListModel> list = dal.GetReadingList(1);
            Assert.AreEqual(true, list[0].HasRead);

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
