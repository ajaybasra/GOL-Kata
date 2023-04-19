using GameOfLife;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using Moq;

namespace GameOfLifeTests;

public class ThreeDimensionalWorldProcessorTests
{
    private readonly ThreeDimensionalWorld _threeDimensionalWorld;
    private readonly Mock<IWorld> _mockedThreeDimensionalWorld;
    private readonly ThreeDimensionalWorldProcessor _threeDimensionalWorldProcessor;
    private readonly List<int> _worldDimensions;

    public ThreeDimensionalWorldProcessorTests()
    {
        _threeDimensionalWorld = new ThreeDimensionalWorld(2, 5, 5, new RNG());
        _mockedThreeDimensionalWorld = new Mock<IWorld>();
        _threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor();
        _worldDimensions = new List<int>() { 2, 5, 5 };
        var threeDimensionalWorld = new Cell[,,]
        {
            {
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead) },
                { new (CellState.Alive), new (CellState.Dead), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
                { new (CellState.Dead), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) }
            },
            {
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Alive) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
                { new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) }
            }
        };
        _mockedThreeDimensionalWorld.Setup(x => x.GetWorldDimensions()).Returns(new List<int>() {2, 5, 5});
        _mockedThreeDimensionalWorld.Setup(x => x.GetArrayOfCells()).Returns(threeDimensionalWorld);
    }
    
    [Fact]
    public void GetNextGeneration_Returns3D2x5x5CellArray_WhenPassedIn2x5x5World()
    {
        var expected = 50;
        var nextGeneration = (Cell[,,])_threeDimensionalWorldProcessor.GetNextGeneration(_threeDimensionalWorld);
        
        Assert.Equal(expected, nextGeneration.Length);
        
    }
    
    [Fact]
    public void GetNextGeneration_CellBecomesAlive_WhenItHasMoreThanThirteenNeighbours()
    {
        var nextGeneration = (Cell[,,])_threeDimensionalWorldProcessor.GetNextGeneration(_mockedThreeDimensionalWorld.Object);
        
        Assert.True(nextGeneration[0, 2, 1].isCellAlive()); 
    }
    
    [Fact]
    public void GetNextGeneration_CellBecomesDead_WhenItHasLessThanThirteenNeighbours()
    {
        var nextGeneration = (Cell[,,])_threeDimensionalWorldProcessor.GetNextGeneration(_mockedThreeDimensionalWorld.Object);
        
        Assert.False(nextGeneration[1, 3, 3].isCellAlive());
    }
    
    [Fact]
    public void GetNextGeneration_CellStaysAlive_WhenItHasMoreThanThirteenNeighbours()
    {
        var nextGeneration = (Cell[,,])_threeDimensionalWorldProcessor.GetNextGeneration(_mockedThreeDimensionalWorld.Object);
        
        Assert.True(nextGeneration[1, 3, 1].isCellAlive());
    }
    
    [Fact]
    public void IsWorldStable_ReturnsFalse_WhenNextGenerationIsDifferent()
    {
        Assert.False(_threeDimensionalWorldProcessor.IsWorldStable(_threeDimensionalWorld.GetArrayOfCells(), _mockedThreeDimensionalWorld.Object.GetArrayOfCells(), _worldDimensions));
    }
    
    [Fact]
    public void IsWorldStable_ReturnsTrue_WhenNextGenerationIsSame()
    {
        Assert.True(_threeDimensionalWorldProcessor.IsWorldStable(_threeDimensionalWorld.GetArrayOfCells(), _threeDimensionalWorld.GetArrayOfCells(), _worldDimensions));
    }
}