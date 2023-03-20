using Bogus;

using Flow.Application.Persistance;
using Flow.Domain.Entities;

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
        var userFaker = new Faker<User>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.Email, x => x.Internet.Email())
            .RuleFor(x => x.PasswordHash, x => x.Internet.Password(10, true))
            .RuleFor(x => x.CreateDate, x => x.Date.Between(new DateTime(2021, 11, 01), new DateTime(2023, 02, 01)));
        var users = userFaker.Generate(15);
        var usersIds = users.Select(x => x.Id).ToList();
        _unitOfWork.Users.CreateMany(users);

        var banksNames = new List<string> { "Альфабанк", "Приорбанк", "МТБ", "Беларусбанк" };
        var banks = banksNames.Select(x => new Bank { Id = Guid.NewGuid(), Name = x, IsActive = true }).ToList();
        var banksIds = banks.Select(x => x.Id).ToList();
        _unitOfWork.Banks.CreateMany(banks);

        var currencies = new List<Currency>
        {
            new Currency
            {
                Id = Guid.NewGuid(),
                Code = "USD",
                Name = "Доллар США"
            },
            new Currency
            {
                Id = Guid.NewGuid(),
                Code = "BYN",
                Name = "Беларуский рубль"
            }
        };
        var currenciesIds = currencies.Select(x => x.Id).ToList();
        _unitOfWork.Currencies.CreateMany(currencies);

        var bankAccountFaker = new Faker<BankAccount>()
            .RuleFor(x => x.Iban, x => x.Finance.Iban())
            .RuleFor(x => x.Amount, x => x.Finance.Amount())
            .RuleFor(x => x.BankId, x => x.PickRandom(banksIds))
            .RuleFor(x => x.CurrencyId, x => x.PickRandom(currenciesIds))
            .RuleFor(x => x.UserId, x => x.PickRandom(usersIds));

        var bankAccounts = bankAccountFaker.Generate(32);
        _unitOfWork.BankAccounts.CreateMany(bankAccounts);

        var cashAccountFaker = new Faker<CashAccount>()
            .RuleFor(x => x.Amount, x => x.Finance.Amount())
            .RuleFor(x => x.CurrencyId, x => x.PickRandom(currenciesIds))
            .RuleFor(x => x.UserId, x => x.PickRandom(usersIds));

        var cashAccounts = cashAccountFaker.Generate(9);
        _unitOfWork.CashAccounts.CreateMany(cashAccounts);

        var subscriptionFaker = new Faker<Subscription>()
              .RuleFor(x => x.Price, x => x.Finance.Amount(0, 100))
              .RuleFor(x => x.CurrencyId, x => x.PickRandom(currenciesIds))
              .RuleFor(x => x.UserId, _ => usersIds.First())
              .RuleFor(x => x.Service, x => x.Company.CompanyName());
        var subscriptions = subscriptionFaker.Generate(10);
        _unitOfWork.Subscriptions.CreateMany(subscriptions);

        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}