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
    }
}