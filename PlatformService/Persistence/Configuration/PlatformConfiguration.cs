using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Persistence.Configuration
{
    public static class PlatformConfiguration
    {
        public static IApplicationBuilder PreparePlatform(this IApplicationBuilder app, bool isProd)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<PlatformDbContext>(), isProd);
            }

            return app;
        }

        private static void SeedData(PlatformDbContext context, bool isProd)
        {
            if(isProd){
                Console.WriteLine("--> Applying migrations...");
                try
                {
                context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not migrate due to: {ex.Message}");
                }
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data");
                context.Platforms.AddRange(
                    new Platform
                    {
                        Id = 1,
                        Name = ".Net",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },
                    new Platform
                    {
                        Id = 2,
                        Name = "Sql Server Express",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },
                    new Platform
                    {
                        Id = 3,
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation",
                        Cost = "Free"
                    });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data already exist");
            }
        }
    }
}