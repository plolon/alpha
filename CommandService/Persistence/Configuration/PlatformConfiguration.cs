
using CommandService.Models;
using CommandService.Persistence.IRepositories;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Persistence.Configuration
{
    public static class PlatformConfiguration
    {
        public static IApplicationBuilder PreparePlatform(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();
                var platforms = grpcClient.ReturnAllPlatforms();
                var repository = serviceScope.ServiceProvider.GetService<IPlatformRepository>();

                SeedData(repository, platforms);

                return app;
            }
        }

        private static void SeedData(IPlatformRepository repo, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("--> Seeding new paltforms...");
            
            foreach (var platform in platforms)
            {
                if(!repo.Exists(platform.ExternalId))
                    repo.Add(platform);
            }
            repo.SaveChanges();
        }
    }
}