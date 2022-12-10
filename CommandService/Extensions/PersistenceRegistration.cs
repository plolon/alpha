using Microsoft.EntityFrameworkCore;
using CommandService.Persistence;
using CommandService.Persistence.IRepositories;
using CommandService.Persistence.Repositories;

namespace CommandService.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommandDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemory");
            });
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            return services;
        }
    }
}