using HW.IServices.BASE;
using HW.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW.IServices
{
    public interface ITopicServices : IBaseServices<Topic>
    {
        Task<List<Topic>> GetTopics();
    }
}
