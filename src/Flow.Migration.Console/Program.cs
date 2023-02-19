using Flow.DataAccess;
using Flow.DataAccess.Extensions;
using Flow.Migration.Console.Seed;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
        .ConfigureServices(
                (host, services) =>
                {
                    var connectionString = host.Configuration.GetConnectionString(nameof(FlowContext));
                    services.AddFlowDbContext(opts => {
                        opts.UseNpgsql(connectionString)
                           .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
                    })
                            .RegisterDataAccessServices();
                    services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
                });
                
var host = builder.Build();

using var scope = host.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<IDatabaseSeeder>();
await seeder!.SeedAsync();
