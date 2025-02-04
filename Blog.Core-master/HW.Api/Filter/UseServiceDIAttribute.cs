﻿using HW.IServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HW.Filter
{
    public class UseServiceDIAttribute : ActionFilterAttribute
    {

        protected readonly ILogger<UseServiceDIAttribute> _logger;
        private readonly ICustServices _blogArticleServices;
        private readonly string _name;

        public UseServiceDIAttribute(ILogger<UseServiceDIAttribute> logger, ICustServices blogArticleServices, string Name = "")
        {
            _logger = logger;
            _blogArticleServices = blogArticleServices;
            _name = Name;
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var dd = _blogArticleServices.Query().Result;
            _logger.LogInformation("测试自定义服务特性");
            Console.WriteLine(_name);
            base.OnActionExecuted(context);
            DeleteSubscriptionFiles();
        }

        private void DeleteSubscriptionFiles()
        {

        }
    }
}
