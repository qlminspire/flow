using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Api.Settings;
using Flow.Application;
using Flow.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(outputTemplate: "[{Timestamp:o} {Level}]: {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

try
{
    Log.Logger.Information("Starting application...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddOptions<DatabaseSettings>()
        .BindConfiguration(DatabaseSettings.ConfigurationSection)
        .ValidateDataAnnotations()
        .ValidateOnStart();

    var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];

    builder.Services.AddDatabase(options => { options.UseNpgsql(connectionString); });
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddFlowSwagger();

    builder.Services.AddHealthChecks()
        .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

    builder.Services.AddHttpContextAccessor();
    builder.Host.UseSerilog(
        (context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });

    builder.Services.AddFlowExceptionHandlers();

    Log.Logger.Information("Total services: {Count}", builder.Services.Count);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseFlowSwagger();
    }

//app.UseHttpsRedirection();
    app.UseExceptionHandler();
    app.UseHealthChecks("/_health");

    app.UseSerilogRequestLogging();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exc)
{
    Log.Logger.Fatal(exc, "Application terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}