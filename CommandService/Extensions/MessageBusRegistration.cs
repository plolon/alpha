using CommandService.AsyncDataServices;
using CommandService.EventProcessing;

namespace PlatformService.Extensions
{
    public static class MessageBusRegistration
    {
        public static IServiceCollection ConfigureMessageBus(this IServiceCollection services)
        {
            services.AddHostedService<MessageBusSubscriber>();
            services.AddSingleton<IEventProcessor, EventProcessor>();
            return services;
        }
    }
}