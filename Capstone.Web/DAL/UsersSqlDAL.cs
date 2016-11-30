using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;

namespace Capstone.Web.DAL
{
    public class UsersSqlDAL : IUsersDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EchoBooks"].ConnectionString;

        public UsersSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserModel GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNewUser(UserModel newUser)
        {
            throw new NotImplementedException();
        }
    }
}