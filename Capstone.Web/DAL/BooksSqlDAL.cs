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


        public List<BookModel> GetBooks(string value, string type)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "Select * from books where {0} like '%{1}%'";
                    sql = sql.Replace("{0}", type);
                    sql = sql.Replace("{1}", value);
                    SqlCommand cmd = new SqlCommand(sql, conn);
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

    }
}