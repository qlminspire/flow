using Flow.Api.Exceptions;
using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Api.Settings;
using Flow.Application;
using Flow.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

builder.Host.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });

builder.Services.AddExceptionHandler<ExceptionLoggingHandler>();
builder.Services.AddExceptionHandler<TimeoutExceptionHandler>();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
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