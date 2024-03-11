namespace Flow.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseFlowSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(x => { x.RouteTemplate = $"{SwaggerConstants.ApiDocsUrl}/{{documentname}}/swagger.json"; });
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint($"/{SwaggerConstants.ApiDocsUrl}/{ApiConstants.Version}/swagger.json",
                SwaggerConstants.ApiTitle);
            x.RoutePrefix = SwaggerConstants.ApiDocsUrl;
        });

        return app;
    }
}