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
        List<BookModel> GetBooks(string value, string type);
        //List<BookModel> GetBooksByKeyword(string keyword);
        BookModel GetBooksById(int bookId);
        bool AddNewBook(BookModel newBook);
        List<BookModel> GetNewBookList();
        List<String> GetNewAuthorList();
    }
}
