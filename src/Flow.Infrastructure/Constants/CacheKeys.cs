namespace Flow.Infrastructure.Constants;

public static class CacheKeys
{
    public static Func<Guid, string> BankById => id => $"banks_id:{id}";
    
    public static Func<string> Banks => () => "banks";
}