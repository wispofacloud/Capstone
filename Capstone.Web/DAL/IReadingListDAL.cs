using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IReadingListDAL
    {
        bool BookAlreadyInList(ReadingListModel model);
        bool AddBookToReadingList(ReadingListModel model);
        bool ChangeBookToHasRead(ReadingListModel model);
        List<ReadingListModel> GetReadingList(int userID);
    }
}
