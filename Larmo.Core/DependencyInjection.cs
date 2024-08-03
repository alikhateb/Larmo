using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Larmo.Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        services.ConfigureGenerics();
    }

    private static void ConfigureGenerics(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}
