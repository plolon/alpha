using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence;
using PlatformService.Persistence.IRepositories;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlatformDbContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
                options.UseInMemoryDatabase("InMemory");
            });
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPlatformRepository, PlatformRepository>();

            return services;
        }
    }
}