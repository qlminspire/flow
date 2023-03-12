using Flow.DataAccess.Contracts;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Flow.Api.Services.Health;

public sealed class DatabaseHealthCheck : IHealthCheck
{
    private readonly IUnitOfWork _unitOfWork;

    public DatabaseHealthCheck(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isDatabaseAvailable = await _unitOfWork.CanConnectAsync(cancellationToken);
        return isDatabaseAvailable ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy("Can't connect to the database");
    }
}
