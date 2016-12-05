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
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;


        public bool BookAlreadyInList(ReadingListModel model)
        {
            List<ReadingListModel> output = new List<ReadingListModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cm = new SqlCommand("select * from readingList where bookID = @bookID and userID = @userID " , conn);
                    cm.Parameters.AddWithValue("@bookID", model.BookID);
                    cm.Parameters.AddWithValue("@userID", model.UserID);                    
                    SqlDataReader reader = cm.ExecuteReader();

                    while(reader.Read())
                    {
                        output.Add( new ReadingListModel{
                            BookID = Convert.ToInt32(reader["bookID"]),
                            UserID = Convert.ToInt32(reader["userID"]),
                            HasRead = Convert.ToBoolean(reader["hasRead"]),
                            
                        });
                    }
                }   
            }
            catch (SqlException e)
            {
                e.Message.ToString();
            }
            return (output.Count > 0);
                
        }

    public bool AddBookToReadingList(ReadingListModel model)
    {
        int rowsAffected = 0;
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into readingList Values (@bookID, @userID, @hasRead, @imageLink);", conn);
                cmd.Parameters.AddWithValue("@bookID", model.BookID);
                cmd.Parameters.AddWithValue("@userID", model.UserID);
                cmd.Parameters.AddWithValue("@hasRead", 0);
                cmd.Parameters.AddWithValue("@imageLink", model.ImageLink);


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
            using (SqlConnection conn = new SqlConnection(connectionString))
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

    public List<ReadingListModel> GetReadingList(int userID)
    {
        List<ReadingListModel> listModel = new List<ReadingListModel>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Select readingList.bookID, readingList.userID, hasRead, author, title, imageLink from readingList inner join books on books.bookID = readingList.bookID inner join users on users.userID = readingList.userID Where readingList.userID = @userID;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listModel.Add(new ReadingListModel()
                    {
                        BookID = Convert.ToInt32(reader["bookID"]),
                        UserID = Convert.ToInt32(reader["userID"]),
                        HasRead = Convert.ToBoolean(reader["hasRead"]),
                        Title = Convert.ToString(reader["title"]),
                        Author = Convert.ToString(reader["author"]),
                        ImageLink=Convert.ToString(reader["imageLink"]),

                    });
                }
            }
        }
        catch (SqlException e)
        {
            e.Message.ToString();
        }
        return listModel;
    }
}
}