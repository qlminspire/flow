using System.Text;
using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Api.Settings;
using Flow.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<DatabaseSettings>()
    .BindConfiguration(DatabaseSettings.ConfigurationSection)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];

builder.Services.AddInfrastructure();
builder.Services.AddDatabase(options => { options.UseNpgsql(connectionString); });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFlowSwagger();

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

builder.Host.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });
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