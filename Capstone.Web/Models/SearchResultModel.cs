using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SearchResultModel
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
        public List<BookModel> Results { get; set; }
    }
}