using Serilog;

using Microsoft.EntityFrameworkCore;

using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Application.Extensions;
using Flow.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseFlowSwagger();

}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/_health");

app.MapControllers();

app.Run();
