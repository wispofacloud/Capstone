using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class PostResultsViewModel
    {
        public ThreadModel SelectedThread { get; set; }
        public List<PostModel> AllPostsInThread = new List<PostModel>();
        public PostModel NewPost { get; set; }
    }
}