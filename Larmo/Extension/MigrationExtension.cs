using Microsoft.EntityFrameworkCore;

namespace Larmo.Extension;

public static class MigrationExtension
{
    /// <summary>
    ///     Adds the automatic migration to the application builder.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <param name="appBuilder">The application builder.</param>
    /// <returns>The application builder.</returns>
    public static IApplicationBuilder UseAutomaticMigration<TContext>(this IApplicationBuilder appBuilder)
        where TContext : DbContext
    {
        using var scope = appBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            ?.CreateScope();

        var context = scope?.ServiceProvider.GetRequiredService<TContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context?.Database.Migrate();
        }

        return appBuilder;
    }
}
