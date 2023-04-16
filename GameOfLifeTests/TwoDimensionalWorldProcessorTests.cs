using GameOfLife;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using Moq;

namespace GameOfLifeTests;

public class TwoDimensionalWorldProcessorTests
{
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly Mock<IWorld> _mockedTwoDimensionalWorld;
    private readonly TwoDimensionalWorldProcessor _twoDimensionalWorldProcessor;
    private readonly TwoDimensionalWorldProcessor _twoDimensionalWorldProcessorUsingMockTwoDimensionalWorld;
    
    public TwoDimensionalWorldProcessorTests()
    {
        _twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
        _mockedTwoDimensionalWorld = new Mock<IWorld>();
        _twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(_twoDimensionalWorld);
        var twoDimensionalWord = new Cell[,]
        {
            { new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) },
            { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead) },
            { new (CellState.Dead), new (CellState.Alive), new (CellState.Dead), new (CellState.Alive), new (CellState.Dead) },
            { new (CellState.Dead), new (CellState.Dead), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
            { new (CellState.Dead), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) },
        };
        _mockedTwoDimensionalWorld.Setup(x => x.GetWorldDimensions()).Returns(new List<int>() {5, 5});
        _mockedTwoDimensionalWorld.Setup(x => x.GetArrayOfCells()).Returns(twoDimensionalWord);
        _twoDimensionalWorldProcessorUsingMockTwoDimensionalWorld = new TwoDimensionalWorldProcessor(_mockedTwoDimensionalWorld.Object);
        
    }

    [Theory]
    [InlineData( 4, 3, 1)]
    [InlineData( 3, 3, 0)]
    [InlineData( 0, 3, 0)]
    [InlineData( 2, 3, 2)]
    [InlineData( 1, 3, 1)]
    [InlineData( -1, 3, 2)]
    [InlineData( -2, 3, 1)]
    [InlineData( -3, 3, 0)]
    [InlineData( -4, 3, 2)]
    public void Mod_ReturnsCorrectOutput_WhenCalled(int x, int m, int expected)
    {
        int actual = _twoDimensionalWorldProcessor.Mod(x, m);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetNextGeneration_Returns2D5x5CellArray_WhenPassedIn5x5World()
    {
        var expected = 25;
        Assert.Equal(expected, _twoDimensionalWorldProcessor.GetNextGeneration().Length);
        
    }
    
    [Fact]
    public void GetNextGeneration_CellBecomesAlive_WhenItHasThreeAliveNeighbours()
    {
        Assert.True(_twoDimensionalWorldProcessorUsingMockTwoDimensionalWorld.GetNextGeneration()[4,4].isCellAlive());
    }
    
    [Fact]
    public void GetNextGeneration_CellBecomesDead_WhenItHasMoreThanThreeNeighbours()
    {
        Assert.False(_twoDimensionalWorldProcessorUsingMockTwoDimensionalWorld.GetNextGeneration()[0,0].isCellAlive());
    }
    
    [Fact]
    public void GetNextGeneration_CellStaysAlive_WhenItHasThreeNeighbours()
    {
        Assert.True(_twoDimensionalWorldProcessorUsingMockTwoDimensionalWorld.GetNextGeneration()[3,4].isCellAlive());
    }
}