namespace Flow.Domain.Banks;

public static class BankErrors
{
    private const string BaseCode = "Bank";

    public static readonly Error NotFound = new(
        $"{BaseCode}.NotFound", "The bank with specified identifier was not found");
}