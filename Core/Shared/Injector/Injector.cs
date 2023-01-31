using api.Domain.Services;
using api.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace api.Shared.Injector
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
