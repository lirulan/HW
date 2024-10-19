using HW.IServices.BASE;
using HW.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW.IServices
{
    public interface ITopicDetailServices : IBaseServices<TopicDetail>
    {
        Task<List<TopicDetail>> GetTopicDetails();
    }
}
