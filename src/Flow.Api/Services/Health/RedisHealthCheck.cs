using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

using Flow.Business.Configurations;

namespace Flow.Api.Services.Health;

public sealed class RedisHealthCheck : IHealthCheck
{
    private readonly IFlowApiConfiguration _configuration;

    public RedisHealthCheck(IFlowApiConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        using var connection = await ConnectionMultiplexer.ConnectAsync(_configuration.FlowRedis);
        return connection.IsConnected ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy("Can't connect to Redis");
    }
}
