using HW.Common;
using HW.IRepository.Base;
using HW.IServices;
using HW.Model.Models;
using HW.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW.Services
{
    public class TopicServices: BaseServices<Topic>, ITopicServices
    {
        /// <summary>
        /// 获取开Bug专题分类（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 60)]
        public async Task<List<Topic>> GetTopics()
        {
            return await base.Query(a => !a.tIsDelete && a.tSectendDetail == "tbug");
        }

    }
}
