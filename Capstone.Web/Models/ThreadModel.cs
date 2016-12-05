using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ThreadModel
    {
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public int CategoryID { get; set; }
        public string ThreadName { get; set; }
        public DateTime ThreadDate { get; set; }
    }
}