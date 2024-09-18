using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Flow.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseFlowSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(x => { x.RouteTemplate = $"{ApiConstants.Swagger.ApiDocsUrl}/{{documentname}}/swagger.json"; });
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint($"/{ApiConstants.Swagger.ApiDocsUrl}/{ApiConstants.Version}/swagger.json",
                ApiConstants.Swagger.ApiTitle);
            x.RoutePrefix = ApiConstants.Swagger.ApiDocsUrl;
        });

        return app;
    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        // Adding health checks endpoints to applications in non-development environments has security implications.
        // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
        if (!app.Environment.IsDevelopment())
            return app;

        // All health checks must pass for app to be considered ready to accept traffic after starting
        app.MapHealthChecks("/health");

        // Only health checks tagged with the "live" tag must pass for app to be considered alive
        app.MapHealthChecks("/alive", new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });

        return app;
    }
}