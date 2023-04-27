using GameOfLife;
using GameOfLife.Enums;

namespace GameOfLifeTests;

public class TwoDimensionalWorldWithoutWraparoundNeighbourProcessorTests
{
    private readonly TwoDimensionalWorldWithoutWraparoundNeighbourProcessor
        _twoDimensionalWorldWithoutWraparoundNeighbourProcessor;

    public TwoDimensionalWorldWithoutWraparoundNeighbourProcessorTests()
    {
        _twoDimensionalWorldWithoutWraparoundNeighbourProcessor =
            new TwoDimensionalWorldWithoutWraparoundNeighbourProcessor();
    }
    
    [Theory]
    [InlineData(0, 0, 5, 5, 3)]
    [InlineData(4, 4, 5, 5, 0)]
    [InlineData(4, 2, 5, 5, 2)]
    [InlineData(1, 4, 5, 5, 1)]
    public void GetNumberOfAliveNeighbours_ReturnsCorrectNumberOfNeighbours_WhenCalled(int currRow, int currCol, int rows, int cols, int expectedNumOfAliveNeighbours)
    {
        var cellArray = new [,]
        {
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead) },
            { new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive) }
        };

        var actualNumOfAliveNeighbours =
            _twoDimensionalWorldWithoutWraparoundNeighbourProcessor.GetNumberOfAliveNeighbours(currRow, currCol, rows, cols, cellArray);
        
        Assert.Equal(expectedNumOfAliveNeighbours, actualNumOfAliveNeighbours);
    }
}