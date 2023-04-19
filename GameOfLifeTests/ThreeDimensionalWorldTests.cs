using GameOfLife;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using Moq;

namespace GameOfLifeTests;

public class ThreeDimensionalWorldTests
{
    private readonly ThreeDimensionalWorld _threeDimensionalWorld;
    private readonly int _rows = 5;
    private readonly int _cols = 5;
    private readonly int _aisles = 2;
    private readonly Mock<IRandomNumberGenerator> _mockRNG;

    public ThreeDimensionalWorldTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _threeDimensionalWorld = new ThreeDimensionalWorld(_aisles, _rows, _cols, _mockRNG.Object);
    }
    
    [Fact]
    public void CheckThreeDimensionalWorldExists_AfterCreatingIt()
    {
        Assert.NotNull(_threeDimensionalWorld);
    }
    
    [Fact]
    public void ThreeDimensionalWorld_Initializes3DArray_WhenCalled()
    {
        var expected = 50;
        
        var actual = (Cell[,,])_threeDimensionalWorld.GetArrayOfCells();
        
        Assert.Equal(expected, actual.Length);
    }
    
    [Fact]
    public void CreateDeadWorld_AllArrayValuesShouldBeDead_WhenConstructorCalled()
    {
        var arrayOfCells = (Cell[,,])_threeDimensionalWorld.GetArrayOfCells();
    
        for (var i = 0; i < _aisles ; i++)
        {
            for (var j = 0; j < _rows; j++)
            {
                for (var k = 0; k < _cols; k++)
                {
                    Assert.False(arrayOfCells[i,j,k].isCellAlive());
                }
            }
        }
    }
    
    [Fact]
    public void RandomizeWorld_AllArrayValuesShouldBeAMixtureOfDeadAndAlive_WhenCalled()
    {
        _mockRNG.SetupSequence(x => x.GetRandomNumber())
            .Returns(0)
            .Returns(1)
            .Returns(0)
            .Returns(1)
            .Returns(1);

        var expectedBooleans = new bool[] { false, true, false, true, true }; // false denotes a dead cell and true denotes an alive cell
        var actualBooleans = new List<bool>{};
    
        _threeDimensionalWorld.RandomizeWorld();
        var arrayOfCells = (Cell[,,])_threeDimensionalWorld.GetArrayOfCells();

        for (var i = 0; i < 1 ; i++) // 1st 2d array
        {
            for (var j = 0; j < 1; j++) // 1st row
            {
                for (var k = 0; k < 5; k++) // five cols
                {
                    actualBooleans.Add(arrayOfCells[i,j,k].isCellAlive());
                }
            }
        }
        
        Assert.Equal(expectedBooleans, actualBooleans.ToArray());
    }
    
    [Fact]
    public void GetWorldDimensions_ReturnsCorrectDimensions_WhenCalled()
    {
        var expected = new List<int> {2, 5, 5};
        
        var actual = _threeDimensionalWorld.GetWorldDimensions();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void UpdateArrayOfCells_Updates3DArray_WhenCalled()
    {
        var newThreeDimensionalWorld = new Cell[,,]
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
        
        _threeDimensionalWorld.UpdateArrayOfCells(newThreeDimensionalWorld);
        var updatedArrayOfCells = (Cell[,,])_threeDimensionalWorld.GetArrayOfCells();

        for (var aisle = 0; aisle < _aisles; aisle++)
        {
            for (var row = 0; row < _rows; row++)
            {
                for (var col = 0; col < _cols; col++)
                {
                    Assert.Equal(newThreeDimensionalWorld[aisle, row, col], updatedArrayOfCells[aisle, row, col]);
                }
            }
        }
    }
}
