﻿using HW.IServices;
using HW.Model;
using HW.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HW.Controllers
{
    /// <summary>
    /// 类别管理【无权限】
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TopicController : ControllerBase
    {
        readonly ITopicServices _topicServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="topicServices"></param>
        public TopicController(ITopicServices topicServices)
        {
            _topicServices = topicServices;
        }

        /// <summary>
        /// 获取Tibug所有分类
        /// </summary>
        /// <returns></returns>
        // GET: api/Topic
        [HttpGet]
        public async Task<MessageModel<List<Topic>>> Get()
        {
            var data = new MessageModel<List<Topic>> {response = await _topicServices.GetTopics()};
            if (data.response != null)
            {
                data.success = true;
                data.msg = "";
            }
            return data;
        }

        // GET: api/Topic/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            return "value";
        }

        // POST: api/Topic
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Topic/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
