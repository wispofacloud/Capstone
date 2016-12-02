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

        public ReviewModel GetReview(int bookID)
        {
            ReviewModel review = new ReviewModel();
            try
            {
                string sqlQueryForGetReview = $"Select * from Review where bookID = @bookID";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQueryForGetReview, conn);
                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        review.BookID = Convert.ToInt32(reader["bookID"]);
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

        public bool SubmitBookReview(ReviewModel post)
        {
            try
            {
                string sqlForSubmitReview = $"Insert into Reviews VALUES(@UserID, @BookID, @Review);";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlForSubmitReview, conn);
                    cmd.Parameters.AddWithValue("@UserID", post.UserID);
                    cmd.Parameters.AddWithValue("@BookID", post.BookID);
                    cmd.Parameters.AddWithValue("@Review", post.Review);
                    
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