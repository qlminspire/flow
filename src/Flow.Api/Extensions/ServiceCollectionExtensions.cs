using System.Reflection;
using Flow.Api.Exceptions;
using Flow.Api.HealthChecks;
using Flow.Api.Metrics;
using Flow.Api.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Flow.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            options.IncludeXmlComments(xmlPath);

            options.SwaggerDoc(ApiConstants.Version, new OpenApiInfo
            {
                Title = ApiConstants.Swagger.ApiTitle,
                Version = ApiConstants.Version,
                Description = "The goal of this API to make personal finance tracking simple"
            });
        });

        return services;
    }

    public static IServiceCollection AddFlowExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<ExceptionLoggingHandler>();
        services.AddExceptionHandler<TimeoutExceptionHandler>();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static IServiceCollection AddFlowOpenTelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource =>
                resource.AddService(DiagnosticsConfig.ServiceName, autoGenerateServiceInstanceId: false,
                    serviceInstanceId: Environment.MachineName))
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();

                metrics.AddMeter(DiagnosticsConfig.Meter.Name);
            }).WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation();
            }).UseOtlpExporter();

        return services;
    }

    public static IServiceCollection AddFlowConfiguration(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(DatabaseSettings.ConfigurationSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }

    public static IServiceCollection AddFlowHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(),
                ["live"]) // Add a default liveness check to ensure app is responsive
            .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

        return services;
    }
}