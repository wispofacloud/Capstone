using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class UsersSqlDAL : IUsersDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        public UserModel GetUser(string username)
        {
            UserModel user = null;
            try
            {
                string sqlQueryForGetUser = $"Select TOP 1 * from users where Username = @username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQueryForGetUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new UserModel();
                        user.UserID = Convert.ToInt32(reader["userID"]);
                        user.Username = Convert.ToString(reader["username"]);
                        user.Password = Convert.ToString(reader["password"]);
                        user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        user.Salt = Convert.ToString(reader["salt"]);
                    }
                }
            }
            catch (SqlException e)
            {
                e.Message.ToString();
                throw;
            }
            return user;
        }

        public UserModel GetUser(string username, string password)
        {
            UserModel user = null;
            try
            {
                string sqlQueryForGetUser = $"Select TOP 1 * from users where Username = @username and password = @password";

                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQueryForGetUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new UserModel();
                        user.UserID = Convert.ToInt32(reader["userID"]);
                        user.Username = Convert.ToString(reader["username"]);
                        user.Password = Convert.ToString(reader["password"]);
                        user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        user.Salt = Convert.ToString(reader["salt"]);
                    }
                }
            }
            catch (SqlException e)
            {
                e.Message.ToString();
                throw;
            }
            return user;
        }

        public bool RegisterNewUser(UserModel newUser)
        {
            try
            {
                string sqlQuery = $"Insert into users values(@isAdmin, @username, @password, @salt);";
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@isAdmin", 0);
                    command.Parameters.AddWithValue("@username", newUser.Username);
                    command.Parameters.AddWithValue("@password", newUser.Password);
                    command.Parameters.AddWithValue("@salt", newUser.Salt);

                    int rowsAffected = command.ExecuteNonQuery();
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