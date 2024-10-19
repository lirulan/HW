using HW.IServices;
using InitQ.Abstractions;
using InitQ.Attributes;
using System;
using System.Threading.Tasks;

namespace HW.Extensions.Redis
{
    public class RedisSubscribe : IRedisSubscribe
    {
        private readonly ICustServices _blogArticleServices;

        public RedisSubscribe(ICustServices blogArticleServices)
        {
            _blogArticleServices = blogArticleServices;
        }

        [Subscribe(RedisMqKey.Loging)]
        private async Task SubRedisLoging(string msg)
        {
            Console.WriteLine($"订阅者 1 从 队列{RedisMqKey.Loging} 消费到/接受到 消息:{msg}");

            await Task.CompletedTask;
        }
    }
}
