using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PlatformDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMem");
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            return services;
        }
    }
}