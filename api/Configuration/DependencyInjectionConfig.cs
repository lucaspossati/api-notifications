using api.Domain.Services;
using api.Domain.Services.Interfaces;
using Data.Repository;
using Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationsRepository>();
        }
    }
}
