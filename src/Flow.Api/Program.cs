using Flow.Api.Extensions;
using Flow.Api.HealthChecks;
using Flow.Application.Extensions;
using Flow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddFlowDbContext(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();

const string apiVersion = "v1";

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc(apiVersion, new OpenApiInfo
    {
        Title = "flow-api",
        Version = apiVersion,
        Description = "The goal of this API to make personal finance tracking simple"
    });

    //c.DocumentFilter<LowerCaseDocumentFilter>();
});

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database");

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwagger(x =>
    {
        x.RouteTemplate = "docs/api/{documentname}/swagger.json";
    });
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint($"/docs/api/{apiVersion}/swagger.json", "Flow API");
        x.RoutePrefix = "docs/api";
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
