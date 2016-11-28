using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IBooksDAL
    {
        List<BookModel> GetBooksByAuthor();
        List<BookModel> GetBooksByTitle();
        List<BookModel> GetBooksBySetting();
        List<BookModel> GetBooksByCharacter();
        List<BookModel> GetBooksByKeyword();
    }
}
