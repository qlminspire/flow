using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Flow.Infrastructure.Extensions;
using Flow.Infrastructure.Persistence;

using Flow.Migration.Console.Extensions;
using Flow.Migration.Console.Seed;

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

await host.MigrateDatabaseAsync<FlowContext>();
