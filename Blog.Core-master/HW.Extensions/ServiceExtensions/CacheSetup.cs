﻿using System.Threading.Tasks;
using HW.Common;
using HW.Common.Caches;
using HW.Common.Caches.Distributed;
using HW.Common.Caches.Interface;
using HW.Common.Option;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

namespace HW.Extensions.ServiceExtensions;

public static class CacheSetup
{
    /// <summary>
    /// 统一注册缓存
    /// </summary>
    /// <param name="services"></param>
    public static void AddCacheSetup(this IServiceCollection services)
    {
        var cacheOptions = App.GetOptions<RedisOptions>();
        if (cacheOptions.Enable)
        {
            // 配置启动Redis服务，虽然可能影响项目启动速度，但是不能在运行的时候报错，所以是合理的
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                //获取连接字符串
                var configuration = ConfigurationOptions.Parse(cacheOptions.ConnectionString, true);
                configuration.ResolveDns = true;
                return ConnectionMultiplexer.Connect(configuration);
            });
            services.AddSingleton(p => p.GetService<IConnectionMultiplexer>() as ConnectionMultiplexer);
            //使用Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConnectionMultiplexerFactory = () => Task.FromResult(App.GetService<IConnectionMultiplexer>(false));
                if (!cacheOptions.InstanceName.IsNullOrEmpty()) options.InstanceName = cacheOptions.InstanceName;
            });

            services.AddTransient<IRedisBasketRepository, RedisBasketRepository>();
        }
        else
        {
            //使用内存
            services.Remove(services.FirstOrDefault(x => x.ServiceType == typeof(IMemoryCache)));
            services.AddSingleton<MemoryCacheManager>();
            services.AddSingleton<IMemoryCache>(provider => provider.GetService<MemoryCacheManager>());
            services.AddOptions();
            services.TryAdd(ServiceDescriptor.Singleton<IDistributedCache, CommonMemoryDistributedCache>());
        }

        services.AddSingleton<ICaching, Caching>();
    }
}