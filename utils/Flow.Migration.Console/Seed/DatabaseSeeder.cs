using Bogus;
using Flow.Application.Contracts.Persistence;
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
        var testingUser = new User
        {
            Id = new Guid("fc8129ce-2ffa-4c99-b6ab-8f525ef8653f"),
            Email = "vladislavq@gmail.com",
            PasswordHash = "1234567",
            CreatedAt = DateTimeOffset.Now,
        };

        var userFaker = new Faker<User>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.Email, x => x.Internet.Email())
            .RuleFor(x => x.PasswordHash, x => x.Internet.Password(10, true))
            .RuleFor(x => x.CreatedAt, x => x.Date.Between(new DateTime(2021, 11, 01), new DateTime(2023, 02, 01)));

        var users = userFaker.Generate(15);
        users.Add(testingUser);

        var usersIds = users.Select(x => x.Id).ToList();
        _unitOfWork.Users.CreateMany(users);

        var banks = GetBanks();
        var banksIds = banks.Select(x => x.Id).ToList();
        _unitOfWork.Banks.CreateMany(banks);

        var currencies = GetCurrencies();
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
              .RuleFor(x => x.UserId, _ => usersIds[0])
              .RuleFor(x => x.Service, x => x.Company.CompanyName());
        var subscriptions = subscriptionFaker.Generate(10);
        _unitOfWork.Subscriptions.CreateMany(subscriptions);

        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static List<Currency> GetCurrencies()
    {
        return new List<Currency>
        {
            new() {
                Id = new Guid("657DF0A1-15E1-4048-A03A-5311AA3D03DF"),
                Code = "USD",
                Name = "Доллар США"
            },
            new() {
                Id = new Guid("9576670B-4D7B-400D-9A8F-30DEBA74E189"),
                Code = "BYN",
                Name = "Беларуский рубль"
            },
            new() {
                Id = new Guid("076EA5EA-92DC-4E73-BCB9-CF5DAC5FF165"),
                Code = "EUR",
                Name = "Евро"
            }
        };
    }

    private static List<Bank> GetBanks()
    {
        return new List<Bank>
        {
            new()
            {
                Id = new Guid("AC95BB73-FD1E-4107-9277-588264C3D906"),
                Name = "Альфабанк",
                IsActive = true
            },
            new()
            {
                Id = new Guid("8E7DC274-FA0C-430F-B6F0-F629259B734B"),
                Name = "Приорбанк",
                IsActive = true
            },
            new()
            {
                Id = new Guid("DCC144C9-0BE0-4B5C-A939-B2E21CC1A0D4"),
                Name = "МТБ",
                IsActive = true
            },
            new()
            {
                Id = new Guid("37AD5D8C-1653-4973-AB3A-4337061CFF5F"),
                Name = "Беларусбанк",
                IsActive = false
            }
        };
    }
}