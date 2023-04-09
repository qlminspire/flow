namespace Flow.Api.Configurations;

internal sealed class FlowApiConfiguration : IFlowApiConfiguration
{
    private readonly IConfiguration _configuration;

    public FlowApiConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? FlowContext => _configuration.GetConnectionString(nameof(FlowContext));

    public string? FlowRedis => _configuration.GetConnectionString(nameof(FlowRedis));
}