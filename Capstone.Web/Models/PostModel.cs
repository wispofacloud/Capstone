using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class PostModel
    {
        public int PostID { get; set; }
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
    }
}