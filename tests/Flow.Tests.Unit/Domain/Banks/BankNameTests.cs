using Flow.Domain.Banks;
using FluentAssertions;

namespace Flow.Tests.Unit.Banks;

public class BankNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("VA")]
    public void Should_ReturnIsFailureTrue_WhenValueIsInvalid(string value)
    {
        // Arrange
        // Act
        var bankName = BankName.Create(value);

        // Assert
        bankName.Should().NotBeNull();
        bankName.IsFailure.Should().BeTrue();
    }
}