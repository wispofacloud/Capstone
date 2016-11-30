using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class OpinionModel
    {
        public string Review { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
    }
}