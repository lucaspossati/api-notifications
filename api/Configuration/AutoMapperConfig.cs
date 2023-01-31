using api.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NotificationProfile));
        }
    }
}
