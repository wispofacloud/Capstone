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
    }
}