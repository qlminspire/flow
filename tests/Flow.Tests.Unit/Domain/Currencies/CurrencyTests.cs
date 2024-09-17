using Flow.Domain.Currencies;
using FluentAssertions;

namespace Flow.Tests.Unit.Domain.Currencies;

public sealed class CurrencyTests
{
    [Fact]
    public void Return_CreatedCurrency_When_IsValid()
    {
        // Arrange
        var createdAt = DateTime.Now;
        var currencyCode = CurrencyCode.Create("EUR");

        // Act
        var result = Currency.Create(currencyCode.Value, createdAt);

        // Assert
        var currency = result.Value;

        currency.Id.Should().NotBeNull();
        currency.Code.Should().Be(currencyCode.Value);
        currency.CreatedAt.Should().Be(createdAt);
        currency.UpdatedAt.Should().BeNull();
        currency.IsDeactivated.Should().BeFalse();
        currency.DeactivatedAt.Should().BeNull();
        currency.GetDomainEvents().Should().HaveCount(1);
    }

    [Fact]
    public void Activate_Currency_When_Deactivated()
    {
        // Arrange
        var activatedAt = DateTime.Now;
        var currency = CreateCurrency("USD", true);

        // Act
        currency.Activate(activatedAt);

        // Assert
        currency.IsDeactivated.Should().BeFalse();
        currency.UpdatedAt.Should().Be(activatedAt);
        currency.DeactivatedAt.Should().BeNull();

        var events = currency.GetDomainEvents();
        events.Should().HaveCount(1);
    }

    [Fact]
    public void DoNothing_When_Activate_ActiveCurrency()
    {
        // Arrange
        var activatedAt = DateTime.Now;
        var currency = CreateCurrency("USD");

        // Act
        currency.Activate(activatedAt);

        // Assert
        currency.IsDeactivated.Should().BeFalse();
        currency.UpdatedAt.Should().BeNull();
        currency.DeactivatedAt.Should().BeNull();

        var events = currency.GetDomainEvents();
        events.Should().HaveCount(0);
    }

    [Fact]
    public void Deactivate_Currency_When_Activated()
    {
        // Arrange
        var deactivatedAt = DateTime.Now;
        var currency = CreateCurrency("EUR");

        // Act
        currency.Deactivate(deactivatedAt);

        // Assert
        currency.IsDeactivated.Should().BeTrue();
        currency.DeactivatedAt.Should().Be(deactivatedAt);

        var events = currency.GetDomainEvents();
        events.Should().HaveCount(1);
    }

    [Fact]
    public void DoNothing_When_Deactivate_NotActiveCurrency()
    {
        // Arrange
        var deactivatedAt = DateTime.Now;
        var currency = CreateCurrency("USD", deactivated: true);

        // Act
        currency.Deactivate(deactivatedAt);

        // Assert
        currency.IsDeactivated.Should().BeTrue();
        currency.DeactivatedAt.Should().NotBeNull();

        var events = currency.GetDomainEvents();
        events.Should().HaveCount(0);
    }

    private static Currency CreateCurrency(string code, bool deactivated = false)
    {
        var currencyCode = CurrencyCode.Create(code).Value;
        var currency = Currency.Create(currencyCode, DateTime.Now).Value;

        if (deactivated)
        {
            var deactivatedAt = DateTime.Now;
            currency.Deactivate(deactivatedAt);
        }

        currency.ClearDomainEvents();

        return currency;
    }
}