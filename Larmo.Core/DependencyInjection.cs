using System.Reflection;
using FluentValidation;
using Larmo.Core.Behaviors;
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
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenRequestPreProcessor(typeof(ValidationProcessor<>));
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
