using Flow.Domain.Abstractions;
using Flow.Domain.Banks;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Migration.Console.Seed;

internal sealed class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;

    public DatabaseSeeder(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var testingUser = User.Create(Email.Create("vladislavq@gmail.com").Value, "1234567", DateTime.UtcNow);
        var users = new[] { testingUser.Value };

        _unitOfWork.Users.CreateMany(users);

        var userCategories = GetDefaultUserCategories(testingUser.Value);
        _unitOfWork.UserCategories.CreateMany(userCategories);

        var banks = GetBanks();
        _unitOfWork.Banks.CreateMany(banks);

        var currencies = GetCurrencies();
        _unitOfWork.Currencies.CreateMany(currencies);

        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static List<Currency> GetCurrencies()
    {
        var date = DateTime.UtcNow;
        string[] currencyCodes = ["USD", "EUR", "BYN"];

        return currencyCodes.Select(code => Currency.Create(CurrencyCode.Create(code).Value, date).Value)
            .ToList();
    }

    private static List<Bank> GetBanks()
    {
        var date = DateTime.UtcNow;
        string[] banks = ["Aльфабанк", "Приорбанк", "МТБ"];

        return banks.Select(name => Bank.Create(BankName.Create(name).Value, date).Value)
            .ToList();
    }

    private static List<UserCategory> GetDefaultUserCategories(User user)
    {
        var date = DateTime.UtcNow;
        string[] categories = ["Жилье", "Путешествия", "Подушка"];

        return categories.Select(name => UserCategory.Create(user, UserCategoryName.Create(name).Value, date).Value)
            .ToList();
    }
}