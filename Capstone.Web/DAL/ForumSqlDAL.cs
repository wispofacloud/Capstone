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

        List<PostModel> output = new List<PostModel>();
        public List<PostModel> GetAllPosts(int threadId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Select * from posts where threadID = @threadID";
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
                            PostDate = Convert.ToDateTime(reader["postDate"])

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

        public List<ThreadModel> GetAllThreads()
        {
            List<ThreadModel> output = new List<ThreadModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Select * from threads;";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new ThreadModel()
                        {
                            ThreadID = Convert.ToInt32(reader["threadID"]),
                            UserID = Convert.ToInt32(reader["userID"]),
                            CategoryID = Convert.ToInt32(reader["categoryID"]),
                            ThreadName = Convert.ToString(reader["threadName"])

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


        public bool SubmitPost(PostModel post)
        {
            throw new NotImplementedException();
        }

        public bool SubmitThread(ThreadModel thread)
        {
            throw new NotImplementedException();
        }
    }
}