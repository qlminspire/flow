namespace Flow.Business.Configurations;

public interface IFlowApiConfiguration
{
    public string? FlowContext { get; }

    public string? FlowRedis { get; }
}
