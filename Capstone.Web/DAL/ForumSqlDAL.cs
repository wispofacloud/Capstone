using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ForumSqlDAL : IForumDAL
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        

        public List<PostModel> GetAllPosts(int threadId)
        {
            List<PostModel> output = new List<PostModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Select postID, posts.threadID, posts.userID, postBody, postDate, users.username, threads.threadname from posts join users on posts.userID = users.userID join threads on threads.threadID = posts.threadID where posts.threadID = @threadID;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@threadID", threadId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new PostModel()
                        {
                            PostID = Convert.ToInt32(reader["postID"]),
                            ThreadID = Convert.ToInt32(reader["threadID"]),
                            UserID = Convert.ToInt32(reader["userID"]),
                            PostBody = Convert.ToString(reader["postBody"]),
                            PostDate = Convert.ToDateTime(reader["postDate"]),
                            Username = Convert.ToString(reader["username"]),
                            ThreadName = Convert.ToString(reader["threadname"])

                        });
                    }
                    return output;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<ThreadModel> GetThreadsByCategory(int categoryID)
        {
            List<ThreadModel> output = new List<ThreadModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Select threadID, userID, categoryID, threadName, threadDate, users.username from threads join users on users.userID = threads.userID where categoryID = @categoryID;";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    cmd2.Parameters.AddWithValue("@categoryID", categoryID);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new ThreadModel()
                        {
                            ThreadID = Convert.ToInt32(reader["threadID"]),
                            UserID = Convert.ToInt32(reader["userID"]),
                            CategoryID = Convert.ToInt32(reader["categoryID"]),
                            ThreadName = Convert.ToString(reader["threadName"]),
                            Username = Convert.ToString(reader["username"]),
                            ThreadDate = Convert.ToDateTime(reader["threadDate"])
                        });
                    }

                    return output;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public ThreadModel GetThreadByThreadID(int threadId)
        {
            ThreadModel thread = new ThreadModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Select threadID, userID, categoryID, threadName, users.username from threads join users on users.userID = threads.userID where threadID = @threadID";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    cmd2.Parameters.AddWithValue("@threadID", threadId);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        thread.ThreadID = Convert.ToInt32(reader["threadID"]);
                        thread.UserID = Convert.ToInt32(reader["userID"]);
                        thread.CategoryID = Convert.ToInt32(reader["categoryID"]);
                        thread.ThreadName = Convert.ToString(reader["threadName"]);
                        thread.Username = Convert.ToString(reader["username"]);

                    }
                    return thread;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool SubmitPost(PostModel post)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into posts Values (@threadID, @userID, @postBody, @postDate, @threadName, @username);", conn);
                    cmd.Parameters.AddWithValue("@threadID", post.ThreadID);
                    cmd.Parameters.AddWithValue("@userID", post.UserID);
                    cmd.Parameters.AddWithValue("@postBody", post.PostBody);
                    cmd.Parameters.AddWithValue("@postDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@threadName", post.ThreadName);
                    cmd.Parameters.AddWithValue("@username", post.Username);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return rowsAffected > 0;
        }

        public bool SubmitThread(ThreadModel thread)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into threads Values (@userID, @categoryID, @threadName, @username, @threadDate;", conn);
                    cmd.Parameters.AddWithValue("@userID", thread.UserID);
                    cmd.Parameters.AddWithValue("@categoryID", thread.CategoryID);
                    cmd.Parameters.AddWithValue("@threadName", thread.ThreadName);
                    cmd.Parameters.AddWithValue("@username", thread.Username);
                    cmd.Parameters.AddWithValue("@threadDate", DateTime.Now.ToShortDateString());

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return rowsAffected > 0;
        }
    }
}