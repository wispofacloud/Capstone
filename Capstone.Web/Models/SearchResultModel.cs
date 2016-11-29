using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class SearchResultModel
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
        public List<BookModel> Results { get; set; } = new List<BookModel>();
        public IEnumerable<SelectListItem> SearchCriteria { get; set; }

        public List<SelectListItem> SearchCriteriaOptions = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Title" },
            new SelectListItem() {Text = "Author" },
            new SelectListItem() {Text = "Setting" },
            new SelectListItem() {Text = "Character" },
            //new SelectListItem() {Text = "Keyword" }

        };


    }
}