using HW.IServices.BASE;
using HW.Model.Models;
using HW.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW.IServices
{
    public interface IBlogArticleServices : IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(long id);

    }

}
