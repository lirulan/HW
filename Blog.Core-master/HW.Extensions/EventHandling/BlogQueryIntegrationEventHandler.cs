using HW.Common;
using HW.EventBus.EventHandling;
using HW.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HW.EventBus
{
    public class BlogQueryIntegrationEventHandler : IIntegrationEventHandler<BlogQueryIntegrationEvent>
    {
        private readonly ICustServices _blogArticleServices;
        private readonly ILogger<BlogQueryIntegrationEventHandler> _logger;

        public BlogQueryIntegrationEventHandler(
            ICustServices blogArticleServices,
            ILogger<BlogQueryIntegrationEventHandler> logger)
        {
            _blogArticleServices = blogArticleServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(BlogQueryIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, "HW", @event);

            ConsoleHelper.WriteSuccessLine($"----- Handling integration event: {@event.Id} at HW - ({@event})");

            await _blogArticleServices.QueryById(@event.BlogId.ToString());
        }

    }
}
