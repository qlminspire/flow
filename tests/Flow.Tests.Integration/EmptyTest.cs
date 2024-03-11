namespace Flow.Tests.Integration;

public class EmptyTest
{
    [Fact]
    public Task TestAsync()
    {
        return Assert.ThrowsAsync<NotImplementedException>(() => throw new NotImplementedException());
    }
}