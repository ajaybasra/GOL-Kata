using GameOfLife;

namespace GameOfLifeTests;

public class ArgumentParserTests
{
    [Fact]
    public void GetChosenGameVersion_ReturnsCorrectValue_WhenCalled()
    {
        var expected = 2;

        var actual = FakeArgumentParser.GetChosenGameVersion();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetWorldDimensions_ReturnsCorrectValue_WhenCalled()
    {
        var expected = new List<int> { 5, 5 };

        var actual = FakeArgumentParser.GetWorldDimensions();
        
        Assert.Equal(expected, actual);
    }
}