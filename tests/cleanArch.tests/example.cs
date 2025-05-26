namespace cleanArch.tests;

public class ExampleTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var expected = 5;
        var actual = 2 + 3;

        // Act & Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Addition_ShouldFail_WhenNumbersAreIncorrect()
    {
        // Arrange
        var expected = 6; // Wrong expected value
        var actual = 2 + 3; // Still equals 5

        // Act & Assert
        Assert.Equal(expected, actual);
    }

}