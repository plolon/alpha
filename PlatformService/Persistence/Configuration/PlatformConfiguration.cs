using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatformService.Models;

namespace PlatformService.Persistence.Configuration
{
    public static class PlatformConfiguration
    {
        public static IApplicationBuilder PreparePlatform(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<PlatformDbContext>());
            }

            return app;
        }

        private static void SeedData(PlatformDbContext context)
        {
            

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