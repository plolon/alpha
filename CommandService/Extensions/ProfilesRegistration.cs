using CommandService.Profiles;

namespace CommandService.Extensions
{
    public static class ProfilesRegistration
    {
        public static IServiceCollection ConfigureProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandsProfile));

            return services;
        }
    }
}