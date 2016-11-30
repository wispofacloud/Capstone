using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "You are required to enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You are required to enter your password")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Salt { get; set; }
    }
}