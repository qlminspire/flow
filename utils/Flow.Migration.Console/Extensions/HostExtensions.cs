using Flow.Migration.Console.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flow.Migration.Console.Extensions;

public static class HostExtensions
{
    public static async Task MigrateDatabaseAsync<TContext>(this IHost host, int retry = 0, int retryAmount = 3,
        CancellationToken cancellationToken = default)
        where TContext : DbContext
    {
        ArgumentNullException.ThrowIfNull(host);

        using var scope = host.Services.CreateScope();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();

        try
        {
            logger.LogInformation(
                "Start migrating database associated with context {DbContextName}.",
                typeof(TContext).Name);

            await context.Database.MigrateAsync(cancellationToken);
            await seeder.SeedAsync(cancellationToken);

            logger.LogInformation(
                "End migrating database associated with context {DbContextName}.",
                typeof(TContext).Name);
        }
        catch (Exception exc)
        {
            logger.LogError(exc, "An error occurred while migrating the database used on context {DbContextName}.",
                typeof(TContext).Name);

            if (retry < retryAmount)
            {
                await Task.Delay(2000, cancellationToken);
                await MigrateDatabaseAsync<TContext>(host, retry + 1, retryAmount, cancellationToken);
            }
        }
    }
}