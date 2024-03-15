namespace Flow.Domain.Accounts;

public static class AccountErrors
{
    private const string BaseCode = "Account";

    public static readonly Error NotFound = new(
        $"{BaseCode}.NotFound", "Account not found");

    public static readonly Error Deactivated = new(
        $"{BaseCode}.Deactivated", "Account deactivated");

    public static readonly Error Deleted = new(
        $"{BaseCode}.Deleted", "Account deleted");

    public static readonly Error NotEnoughMoney =
        new($"{BaseCode}.NotEnoughMoney", "Account does not have enough money");

    public static readonly Error DeleteRestrictedForPositiveBalance = new(
        $"{BaseCode}.DeleteRestricted.PositiveBalance", "Can't delete account with positive balance");
}