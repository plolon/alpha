using PlatformService.AsyncDataServices;

namespace PlatformService.Extensions
{
    public static class MessageBusRegistration
    {
        public static IServiceCollection ConfigureMessageBus(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            return services;
        }
    }
}