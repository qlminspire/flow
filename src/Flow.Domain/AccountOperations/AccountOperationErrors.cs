namespace Flow.Domain.AccountOperations;

public static class AccountOperationErrors
{
    private const string BaseErrorCode = "AccountOperation.Restricted";

    public static readonly Error OperationDeleted = new(
        $"{BaseErrorCode}.Deleted", "The operation is deleted");

    public static readonly Error OneOfTheAccountsIsDeleted = new(
        $"{BaseErrorCode}.OneOfTheAccountsIsDeleted", "One of the accounts is deleted");

    public static readonly Error OneOfTheAccountsIsDeactivated = new(
        $"{BaseErrorCode}.OneOfTheAccountsIsDeactivated", "One of the accounts is deactivated");

    public static readonly Error SameSourceAndTargetAccount = new(
        $"{BaseErrorCode}.SameSourceAndTargetAccount", "The source and target accounts are same");

    public static readonly Error ZeroAmount = new(
        $"{BaseErrorCode}.ZeroAmount", "The operation can not be created with 0 amount");

    public static readonly Error NegativeAmount = new(
        $"{BaseErrorCode}.NegativeAmount", "The operation can not be created with 0 amount");

    public static readonly Error NotEnoughMoneyOnSourceAccount = new(
        $"{BaseErrorCode}.NotEnoughMoneyOnSourceAccount", "The source account does not have enough money");
}