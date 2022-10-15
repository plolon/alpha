using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence;
using PlatformService.Persistence.IRepositories;
using PlatformService.Persistence.Repositories;

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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPlatformRepository, PlatformRepository>();

            return services;
        }
    }
}