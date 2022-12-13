using CommandService.AsyncDataServices;

namespace PlatformService.Extensions
{
    public static class MessageBusRegistration
    {
        public static IServiceCollection ConfigureMessageBus(this IServiceCollection services)
        {
            services.AddHostedService<MessageBusSubscriber>();
            return services;
        }
    }
}