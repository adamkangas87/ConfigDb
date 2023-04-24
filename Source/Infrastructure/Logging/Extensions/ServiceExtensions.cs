using Logging.Interfaces;
using Logging.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Logging.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLoggingServices(this IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();
            services.AddScoped(typeof(ILogService<>), typeof(LogService<>));
            return services;
        }

        public static IHostBuilder AddLogging(this IHostBuilder host)
        {
            host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
            return host;
        }



    }
}
