using Xunit;
using Moq;
using TestingSamples;

namespace TestingSamples.Tests;

/// <summary>
/// Interview topic: Unit testing with xUnit — arrange, act, assert.
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _sut = new();

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Add_ReturnsSum(int a, int b, int expected)
    {
        var result = _sut.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(10, 0));
    }
}

public class UserServiceTests
{
    [Fact]
    public async Task GetDisplayNameAsync_UserExists_ReturnsName()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new User(1, "Alice"));
        var sut = new UserService(mockRepo.Object);

        // Act
        var name = await sut.GetDisplayNameAsync(1);

        // Assert
        Assert.Equal("Alice", name);
        mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetDisplayNameAsync_UserNotFound_ReturnsUnknown()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);
        var sut = new UserService(mockRepo.Object);

        var name = await sut.GetDisplayNameAsync(99);

        Assert.Equal("Unknown", name);
    }
}
