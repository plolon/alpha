using PlatformService.SyncDataServices.Http;

namespace PlatformService.Extensions
{
    public static class HttpClientRegistration
    {
        public static IServiceCollection ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

            return services;
        }
    }
}