using Flow.Infrastructure;
using Flow.Infrastructure.Persistence;
using Flow.Migration.Console.Extensions;
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
            services.AddDatabase(opts =>
            {
                opts.UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
            });
            services.AddInfrastructure();
            services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
        });

var host = builder.Build();

await host.MigrateDatabaseAsync<FlowContext>();