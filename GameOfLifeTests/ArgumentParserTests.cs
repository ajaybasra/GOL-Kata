using GameOfLife;
using GameOfLife.Interfaces;
using Moq;

namespace GameOfLifeTests;

public class ArgumentParserTests
{
    private readonly ArgumentParser _argumentParser;
    private readonly Mock<ICommandLine> _mockedCommandLine;
    private readonly string[] expectedArgs = { "pathname", "2", "5", "5" };
    public ArgumentParserTests()
    {
        _mockedCommandLine = new Mock<ICommandLine>();
        _mockedCommandLine.Setup(x => x.GetCommandLineArgs()).Returns(expectedArgs);
        _argumentParser = new ArgumentParser(_mockedCommandLine.Object);
    }

    [Fact]
    public void GetCommandLineArgs_ReturnsRightOutput_WhenCalled()
    {
        var actual = _mockedCommandLine.Object.GetCommandLineArgs();
        
        Assert.Equal(expectedArgs, actual);
    }
    
    [Fact]
    public void GetChosenGameVersion_ReturnsCorrectValue_WhenCalled()
    {
        var expected = 2;

        var actual = _argumentParser.GetChosenGameVersion();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetWorldDimensions_ReturnsCorrectValue_WhenCalled()
    {
        var expected = new List<int> { 5, 5 };

        var actual = _argumentParser.GetWorldDimensions();
        
        Assert.Equal(expected, actual);
    }
}
