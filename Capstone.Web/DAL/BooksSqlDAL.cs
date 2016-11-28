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

        public BooksSqlDAL(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public List<BookModel> GetBooksByAuthor(string author)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select author from books where author = @author", conn);
                    cmd.Parameters.AddWithValue("@author", author);
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
                            DateAdded = Convert.ToDateTime(reader["dateAdded"])
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

        public List<BookModel> GetBooksByCharacter(string character)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select mainCharacter from books where character = @character", conn);
                    cmd.Parameters.AddWithValue("@character", character);
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
                            DateAdded = Convert.ToDateTime(reader["dateAdded"])
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

        public List<BookModel> GetBooksByKeyword(string keyword)
        {
            List<BookModel> output = new List<BookModel>();
            string sqlString = "Select * from books WHERE title";//need to finish this
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlString, conn);
                    cmd.Parameters.AddWithValue("@keyword", keyword);
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
                            DateAdded = Convert.ToDateTime(reader["dateAdded"])
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


        public List<BookModel> GetBooksBySetting(string setting)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select setting from books where setting = @setting", conn);
                    cmd.Parameters.AddWithValue("@setting", setting);
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
                            DateAdded = Convert.ToDateTime(reader["dateAdded"])
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


        public List<BookModel> GetBooksByTitle(string title)
        {
            List<BookModel> output = new List<BookModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select title from books where title = @title", conn);
                    cmd.Parameters.AddWithValue("@title", title);
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
                            DateAdded = Convert.ToDateTime(reader["dateAdded"])
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

    }
}