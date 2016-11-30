using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class AwardsModel
    {
        public string Category { get; set; }
        public string ListOfTitles { get;  set;}
        public string ListOfCharacters { get; set; }
        public DateTime EndDate { get; set; }
    }
}