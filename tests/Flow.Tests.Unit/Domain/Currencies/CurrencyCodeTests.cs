using Flow.Domain.Abstractions;
using Flow.Domain.Currencies;
using FluentAssertions;

namespace Flow.Tests.Unit.Domain.Currencies;

public sealed class CurrencyCodeTests
{
    [Fact]
    public void Return_NullValueError_When_CurrencyCode_Is_Null()
    {
        // Arrange

        // Act
        var result = CurrencyCode.Create(null);

        // Assert
        result.Should().NotBeNull();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Error.NullValueError);
    }

    [Theory]
    [InlineData("EUR O")]
    [InlineData("EU")]
    [InlineData("EURO")]
    [InlineData("E R")]
    public void Return_ExactLengthError_When_CurrencyCode_Length_Not_ThreeLetters(string currencyCode)
    {
        // Arrange

        // Act
        var result = CurrencyCode.Create(currencyCode);

        // Assert
        result.Error.Should().Be(Error.ExactLengthError(3));
    }

    [Theory]
    [InlineData("EUR", "EUR")]
    [InlineData("usd ", "USD")]
    [InlineData(" BYn", "BYN")]
    [InlineData("R U B", "RUB")]
    public void Return_CreatedCurrencyCode_When_CurrencyCode_Valid(string value, string expected)
    {
        // Arrange

        // Act
        var result = CurrencyCode.Create(value);

        // Assert
        var currencyCode = result.Value;
        currencyCode.Value.Should().Be(expected);
    }
}