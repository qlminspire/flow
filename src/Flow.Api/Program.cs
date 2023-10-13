using System.Text;
using Serilog;

using Microsoft.EntityFrameworkCore;

using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Api.Settings;
using Flow.Application.Extensions;
using Flow.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<DatabaseSettings>()
    .BindConfiguration(DatabaseSettings.ConfigurationSection)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];

builder.Services.AddFlowApplication();
builder.Services.AddFlowInfrastructure();
builder.Services.AddFlowDbContext(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFlowSwagger();

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
Console.OutputEncoding = Encoding.UTF8;

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseFlowSwagger();
}

//app.UseHttpsRedirection();
app.UseHealthChecks("/_health");

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
