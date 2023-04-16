using GameOfLife.Enums;
using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorldProcessor
{
    private IWorld _world;
    private readonly int _rows;
    private readonly int _cols;
    private readonly Cell[,] _oldGeneration;

    public TwoDimensionalWorldProcessor(IWorld world)
    {
        _world = world;
        _rows = world.GetWorldDimensions()[0];
        _cols = world.GetWorldDimensions()[1];
        _oldGeneration = _world.GetArrayOfCells();
    }

    public Cell[,] GetNextGeneration()
    {
        var nextGeneration = new Cell[_rows, _cols];
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                var currentCell = _oldGeneration[row, col];
                var numberOfAliveNeighbours = GetNumberOfAliveNeighbours(row, col);
   
                if (currentCell.isCellAlive() && numberOfAliveNeighbours < 2)
                {
                    nextGeneration[row,col] = new Cell(CellState.Dead);
                }
                else if (currentCell.isCellAlive() && numberOfAliveNeighbours > 3)
                {
                    nextGeneration[row, col] = new Cell(CellState.Dead);
                }
                else if (!currentCell.isCellAlive() && numberOfAliveNeighbours == 3)
                {
                    nextGeneration[row,col] = new Cell(CellState.Alive);
                }
                else
                {
                    nextGeneration[row, col] = new Cell(currentCell.GetCellState());
                }
            }
        }
        return nextGeneration;
    }

    public int Mod(int x, int m) // works for negative numbers too unlike % operator
    {
        var r = x % m;
        return r<0 ? r+m : r;
    }

    private int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)
        {
            for (var j= -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                var neighbourRow = Mod((currentCellRow + i), _rows);
                var neighbourCol = Mod((currentCellCol + j), _cols);
                aliveNeighbours += _oldGeneration[neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;

            }
        }
        return aliveNeighbours;
    }
    
}