using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class MyEchoBooksViewModel
    {
        public UserModel CurrentUser { get; set; }
        public List<ReadingListModel> ReadingList { get; set; }

    }
}