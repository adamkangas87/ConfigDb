using Persistance.Extensions;
using Application.Extensions;
using Logging.Extensions;
namespace WebUi.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLoggingServices();
            services.AddApplicationServices();
            services.AddPersistanceServices(configuration);
            return services;
        }
    }
}
