using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string MainCharacter { get; set; }
        public string Setting { get; set; }
        public string Genre { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
       

       

    }
}