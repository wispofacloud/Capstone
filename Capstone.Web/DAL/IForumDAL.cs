using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{

    public interface IForumDAL
    {
        bool SubmitThread(ThreadModel thread);
        bool SubmitPost(PostResultsViewModel NewPost);
        List<ThreadModel> GetThreadsByCategory(int categoryID);
        List<PostModel> GetAllPosts(int threadId);
        ThreadModel GetThreadByThreadID(int threadId);
        List<CategoriesModel> GetAllCategories();
    }
}
