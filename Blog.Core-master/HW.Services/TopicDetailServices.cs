﻿using HW.Common;
using HW.IRepository.Base;
using HW.IServices;
using HW.Model.Models;
using HW.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW.Services
{
    public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
        /// <summary>
        /// 获取开Bug数据（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<TopicDetail>> GetTopicDetails()
        {
            return await base.Query(a => !a.tdIsDelete && a.tdSectendDetail == "tbug");
        }
    }
}
