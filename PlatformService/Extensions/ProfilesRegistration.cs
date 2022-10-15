using PlatformService.Profiles;

namespace PlatformService.Extensions
{
    public static class ProfilesRegistration
    {
        public static IServiceCollection ConfigureProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PlatformsProfile));

            return services;
        }
    }
}