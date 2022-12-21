using CommandService.SyncDataServices.Grpc;

namespace CommandService.Extensions
{
    public static class DataServicesRegistration
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPlatformDataClient, PlatformDataClient>();
            return services;
        }
    }
}