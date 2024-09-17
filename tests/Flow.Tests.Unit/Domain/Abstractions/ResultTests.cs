using Flow.Domain.Abstractions;
using Flow.Domain.Currencies;
using FluentAssertions;

namespace Flow.Tests.Unit.Domain.Abstractions;

public sealed class ResultTests
{
    [Fact]
    public void SuccessResult_Has_NoneError()
    {
        // Arrange

        // Act
        var result = Result.Success();

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void FailureResult_Has_Error()
    {
        // Arrange

        // Act
        var result = Result.Failure(Error.NullValueError);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Error.NullValueError);
    }

    [Fact]
    public void SuccessResult_When_Create_Result_Passing_ValidValue()
    {
        // Arrange
        var currencyCode = CurrencyCode.Create("EUR").Value;
        var currency = Currency.Create(currencyCode, DateTime.Now).Value;

        // Act
        var result = Result.Create(currency);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(currency);
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void NullValueErrorResult_When_Create_Result_Passing_Null()
    {
        // Arrange

        // Act
        var result = Result.Create<Currency>(null);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Error.NullValueError);
    }
}