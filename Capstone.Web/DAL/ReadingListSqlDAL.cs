using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ReadingListSqlDAL : IReadingListDAL
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        public bool AddBookToReadingList(ReadingListModel model)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into readingList Values (@bookID, @userID, @hasRead);", conn);
                    cmd.Parameters.AddWithValue("@bookID", model.BookID);
                    cmd.Parameters.AddWithValue("@userID", model.UserID);
                    cmd.Parameters.AddWithValue("@hasRead", 0);


                    rowsAffected = cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e)
            {
                e.Message.ToString();
                throw;
            }
            return rowsAffected > 0;

        }

        public bool ChangeBookToHasRead(ReadingListModel model)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Update readingList Set hasReAD = @hasRead where userID = @userID AND bookID = @bookID;", conn);
                    cmd.Parameters.AddWithValue("@hasRead", 1);
                    cmd.Parameters.AddWithValue("@userID", model.UserID);
                    cmd.Parameters.AddWithValue("@bookID", model.BookID);
                    
                    rowsAffected = cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return rowsAffected > 0;

        }
    }
}