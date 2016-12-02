using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Web.Models
{
    public class BooksSqlDAL : IBooksDAL
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        private Dictionary<string, string> Choices = new Dictionary<string, string>()
        {
            { "Author", "SELECT * FROM books WHERE author like '%{1}%'"},
            { "Title","SELECT * FROM books WHERE title like '%{1}%'"},
            { "Setting","SELECT * FROM books WHERE setting like '%{1}%'"},
            {"Character", "SELECT * FROM books WHERE mainCharacter like '%{1}%'"}
        };

        public List<BookModel> GetBooks(string value, string type)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    if (Choices.ContainsKey(type))
                    {
                        string sql = Choices[type];
                        sql = sql.Replace("{1}", value);
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@value", value);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            output.Add(new BookModel()
                            {
                                BookID = Convert.ToInt32(reader["bookID"]),
                                Title = Convert.ToString(reader["title"]),
                                Author = Convert.ToString(reader["author"]),
                                MainCharacter = Convert.ToString(reader["mainCharacter"]),
                                Setting = Convert.ToString(reader["setting"]),
                                Genre = Convert.ToString(reader["genre"]),
                                DateAdded = Convert.ToDateTime(reader["dateAdded"]),
                                ImageLink = Convert.ToString(reader["imageLink"])
                            });
                        }
                    }
                    else
                    {
                        return output;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        public BookModel GetBooksById(int bookId)
        {
            BookModel output = new BookModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "Select * from books where bookId = @bookId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.BookID = Convert.ToInt32(reader["bookID"]);
                        output.Title = Convert.ToString(reader["title"]);
                        output.Author = Convert.ToString(reader["author"]);
                        output.MainCharacter = Convert.ToString(reader["mainCharacter"]);
                        output.Setting = Convert.ToString(reader["setting"]);
                        output.Genre = Convert.ToString(reader["genre"]);
                        output.DateAdded = Convert.ToDateTime(reader["dateAdded"]);
                        output.Description = Convert.ToString(reader["description"]);
                        output.ImageLink = Convert.ToString(reader["imageLink"]);

                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        public bool AddNewBook(BookModel newBook)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into books Values (@title, @author, @mainCharacter, @setting, @genre, @dateAdded, @description, @imageLink);", conn);
                    cmd.Parameters.AddWithValue("@title", newBook.Title);
                    cmd.Parameters.AddWithValue("@author", newBook.Author);
                    cmd.Parameters.AddWithValue("@mainCharacter", newBook.MainCharacter);
                    cmd.Parameters.AddWithValue("@setting", newBook.Setting);
                    cmd.Parameters.AddWithValue("@genre", newBook.Genre);
                    cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@description", newBook.Description);
                    cmd.Parameters.AddWithValue("@imageLink", newBook.ImageLink);

                    rowsAffected = cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return rowsAffected > 0;

        }

        public List<BookModel> GetNewBookList()
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();


                    string sql = "Select * from books where dateAdded > @threshold;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@threshold", DateTime.Now.AddDays(-30));
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        output.Add(new BookModel()
                        {
                            BookID = Convert.ToInt32(reader["bookID"]),
                            Title = Convert.ToString(reader["title"]),
                            Author = Convert.ToString(reader["author"]),
                            MainCharacter = Convert.ToString(reader["mainCharacter"]),
                            Setting = Convert.ToString(reader["setting"]),
                            Genre = Convert.ToString(reader["genre"]),
                            DateAdded = Convert.ToDateTime(reader["dateAdded"]),
                            ImageLink = Convert.ToString(reader["imageLink"])
                        });
                    }

                    return output;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}







//public List<BookModel> GetBooksByKeyword(string keyword)
//{
//    List<BookModel> output = new List<BookModel>();
//    string sqlString = "Select * from books WHERE title";//need to finish this
//    try
//    {
//        using (SqlConnection conn = new SqlConnection(ConnectionString))
//        {
//            conn.Open();
//            SqlCommand cmd = new SqlCommand(sqlString, conn);
//            cmd.Parameters.AddWithValue("@keyword", keyword);
//            SqlDataReader reader = cmd.ExecuteReader();

//            while (reader.Read())
//            {
//                output.Add(new BookModel()
//                {
//                    BookID = Convert.ToInt32(reader["bookID"]),
//                    Title = Convert.ToString(reader["title"]),
//                    Author = Convert.ToString(reader["author"]),
//                    MainCharacter = Convert.ToString(reader["mainCharacter"]),
//                    Setting = Convert.ToString(reader["setting"]),
//                    Genre = Convert.ToString(reader["genre"]),
//                    DateAdded = Convert.ToDateTime(reader["dateAdded"])
//                });
//            }
//        }

//    }
//    catch (SqlException e)
//    {
//        Console.WriteLine(e.Message);
//    }
//    return output;
//}

