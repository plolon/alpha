using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence;
using PlatformService.Persistence.IRepositories;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddDbContext<PlatformDbContext>(options =>
            {
                if (environment.IsProduction())
                {
                    System.Console.WriteLine("--> Using SqlServer DataBase");
                    options.UseSqlServer(configuration.GetConnectionString("PlatformsConn"));
                }
                else
                {
                    System.Console.WriteLine("--> Using InMemory DataBase");
                    options.UseInMemoryDatabase("InMemory");
                }
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