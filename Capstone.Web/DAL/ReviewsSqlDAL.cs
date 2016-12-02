using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{

    public class ReviewsSqlDAL : IReviewsDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        public ReviewModel GetReview(string title)
        {
            ReviewModel review = new ReviewModel();
            try
            {
                string sqlQueryForGetReview = $"Select * from Review where title = @title";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQueryForGetReview, conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        review.Title = Convert.ToString(reader["title"]);
                        review.Review = Convert.ToString(reader["review"]);

                    }
                }
            }
            catch(SqlException e)
            {
                e.Message.ToString();
                throw;
            }
            return review;
        }

        public bool SubmitReview(ReviewModel post)
        {
            try
            {
                string sqlForSubmitReview = $"Insert into Review VALUES(@UserID, @BookID, @Review, @Title);";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlForSubmitReview, conn);
                    cmd.Parameters.AddWithValue("@UserID", post.UserID);
                    cmd.Parameters.AddWithValue("@BookID", post.BookID);
                    cmd.Parameters.AddWithValue("@Review", post.Review);
                    cmd.Parameters.AddWithValue("@Title", post.Title);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
            catch (SqlException e)
            {
                e.Message.ToString();
                throw;
            }
        }
    }
}