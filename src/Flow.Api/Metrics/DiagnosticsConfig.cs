using System.Diagnostics.Metrics;

namespace Flow.Api.Metrics;

public static class DiagnosticsConfig
{
    public const string ServiceName = "Flow";

    public static readonly Meter Meter = new(ServiceName);

    public static readonly Counter<int> BankAccountsCounter = Meter.CreateCounter<int>("bank_accounts.count");
}