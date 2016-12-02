using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IReviewsDAL
    {
        ReviewModel GetReview(int bookID);
        bool SubmitBookReview(ReviewModel post);
    }
}
