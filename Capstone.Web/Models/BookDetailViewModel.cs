using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class BookDetailViewModel
    {
        public UserModel CurrentUser { get; set; }
        public BookModel CurrentBook { get; set; }
        public ReviewModel CurrentReview { get; set; }
        public ReadingListModel CurrentReadingList { get; set; }
        public bool IsBookInList { get; set; }
    }


}