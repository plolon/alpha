using PlatformService.SyncDataServices.Http;

namespace PlatformService.Extensions
{
    public static class HttpClientRegistration
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            services.AddGrpc();
            return services;
        }
    }
}