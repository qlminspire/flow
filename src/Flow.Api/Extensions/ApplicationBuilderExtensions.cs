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
}