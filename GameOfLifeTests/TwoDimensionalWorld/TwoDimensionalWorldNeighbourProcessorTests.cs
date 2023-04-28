using GameOfLife;
using GameOfLife.Enums;

namespace GameOfLifeTests;

public class TwoDimensionalWorldNeighbourProcessorTests
{
    private readonly TwoDimensionalWorldNeighbourProcessor _twoDimensionalWorldNeighbourProcessor;

    public TwoDimensionalWorldNeighbourProcessorTests()
    {
        _twoDimensionalWorldNeighbourProcessor = new TwoDimensionalWorldNeighbourProcessor();
    }
    
    [Theory]
    [InlineData(0, 0, 5, 5, 6)]
    [InlineData(4, 4, 5, 5, 3)]
    [InlineData(4, 2, 5, 5, 1)]
    [InlineData(1, 4, 5, 5, 4)]
    [InlineData(2, 3, 5, 5, 0)]
    [InlineData(1, 2, 5, 5, 2)]
    public void GetNumberOfAliveNeighbours_ReturnsCorrectNumberOfNeighbours_WhenCalled(int currRow, int currCol, int rows, int cols, int expectedNumOfAliveNeighbours)
    {
        var cellArray = new [,]
        {
            { new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive) }
        };

        var actualNumOfAliveNeighbours =
            _twoDimensionalWorldNeighbourProcessor.GetNumberOfAliveNeighbours(currRow, currCol, rows, cols, cellArray);
        
        Assert.Equal(expectedNumOfAliveNeighbours, actualNumOfAliveNeighbours);
    }
}