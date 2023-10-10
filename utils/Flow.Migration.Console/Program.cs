using Flow.Infrastructure.Extensions;
using Flow.Infrastructure.Persistence;
using Flow.Migration.Console.Seed;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
        .ConfigureServices(
                (host, services) =>
                {
                    var connectionString = host.Configuration["DatabaseSettings:ConnectionString"];
                    services.AddFlowDbContext(opts =>
                    {
                        opts.UseNpgsql(connectionString)
                           .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
                    });
                    services.AddFlowInfrastructure();
                    services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
                });

var host = builder.Build();

using var scope = host.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<FlowContext>();

var databaseCreated = await context.Database.EnsureCreatedAsync();
if (!databaseCreated)
{
    await context.Database.MigrateAsync();
    Console.WriteLine("Database migration applied");
}

var seeder = scope.ServiceProvider.GetService<IDatabaseSeeder>();
await seeder!.SeedAsync();

Console.WriteLine("Database seeded");
