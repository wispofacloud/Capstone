using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public interface IBooksDAL
    {
        List<BookModel> GetBooksByAuthor(string author);
        List<BookModel> GetBooksByTitle(string title);
        List<BookModel> GetBooksBySetting(string setting);
        List<BookModel> GetBooksByCharacter(string character);
        List<BookModel> GetBooksByKeyword(string keyword);
    }
}
