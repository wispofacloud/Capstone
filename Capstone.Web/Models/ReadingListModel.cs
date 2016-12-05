using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ReadingListModel
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public bool HasRead { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Username { get; set; }
        private string imageLink = "";

        public string ImageLink
        {
            get { return imageLink; }
            set { imageLink = value; }
        }

    }
}