using Larmo.Core.Repository;
using Larmo.Infrastructure.Context;
using Larmo.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Larmo.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureContext(configuration);
        services.ConfigureGenerics();
    }

    private static void ConfigureGenerics(this IServiceCollection services)
    {
        services.AddScoped<IOperationRepository, OperationRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
    }

    private static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5);
            });
        });
    }
}
