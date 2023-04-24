
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Services;
using Microsoft.AspNetCore.Builder;
using Logging.Interfaces;

namespace Persistance.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(DataContext)), x => x.MigrationsHistoryTable("Migrations", "Configuration")));

            services.AddScoped<DataContextSeed>();
            services.AddScoped<IMigrationService, MigrationService>();
            services.AddScoped<ISeedService, SeedService>();
            return services;
        }

        public static async Task<bool> Migrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    services.GetRequiredService<ILogService<IMigrationService>>().LogInformation($"Running migrations");
                    var datamigration = services.GetService<IMigrationService>();
                    if (datamigration != null)
                    {
                        
                        await datamigration.MigrateAsync();
                    }
                }
                catch (Exception ex)
                {
                    services.GetRequiredService<ILogService>().LogError(ex, "An error occurred while running database migrations.");
                    return false;
                }
            }
            return true;
        }

        public static async Task<bool> Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    services.GetRequiredService<ILogService<ISeedService>>().LogInformation($"Running database seed");
                    var dataseed = services.GetService<ISeedService>();
                    if (dataseed != null)
                    {
                        await dataseed.SeedAsync();
                    }
                }
                catch (Exception ex)
                {
                    services.GetRequiredService<ILogService>().LogError(ex, "An error occurred while running database seeding.");
                    return false;
                }
            }
            return true;
        }
    }
}
