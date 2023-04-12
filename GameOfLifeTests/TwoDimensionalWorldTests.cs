using GameOfLife;
using GameOfLife.Enums;

namespace GameOfLifeTests;

public class TwoDimensionalWorldTests
{
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly int _rows = 5;
    private readonly int _cols = 5;
    
    public TwoDimensionalWorldTests()
    {
        _twoDimensionalWorld = new TwoDimensionalWorld(_rows, _cols);
    }

    [Fact]
    public void CheckTwoDimensionalWorldExists_AfterCreatingIt()
    {
        Assert.NotNull(_twoDimensionalWorld);
    }

    [Fact]
    public void TwoDimensionalWorld_Initializes2DArray_WhenCalled()
    {
        var expected = 25;
        
        var actual = _twoDimensionalWorld.GetArrayOfCells();
        
        Assert.Equal(expected, actual.Length);
    }

    [Fact]
    public void CreateDeadWorld_AllArrayValuesShouldBeDead_WhenConstructorCalled()
    {
        var expectedRow = new Cell[] { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) };

        var arrayOfCells = _twoDimensionalWorld.GetArrayOfCells();
        var actualRow = Enumerable.Range(0, arrayOfCells.GetLength(1))
            .Select(x => arrayOfCells[0, x])
            .ToArray();
        
        for (var i = 0; i < expectedRow.Length; i++)
        {
            Assert.Equal(expectedRow[i].GetCellStateAsString(), actualRow[i].GetCellStateAsString());
        } // have to compare GetCellStateAsString output as comparing two objects directly does not work, because it compares their ref values
    }

    [Fact]
    public void RandomizeWorld_AllArrayValuesShouldBeAMixtureOfDeadAndAlive_WhenCalled()
    {
        
    }
    
    [Fact]
    public void GetWorldDimensions_ReturnsCorrectDimensions_WhenCalled()
    {
        var expected = new List<int> {5, 5};
        
        var actual = _twoDimensionalWorld.GetWorldDimensions();
        
        Assert.Equal(expected, actual);
    }
}