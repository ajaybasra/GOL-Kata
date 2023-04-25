using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class TwoDimensionalWorldWithoutWraparoundProcessor : IWorldProcessor
{
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly TwoDimensionalWorldDisplayBuilder _twoDimensionalWorldDisplayBuilder;
    private Cell[,] _oldGeneration;
    private Cell[,] _newGeneration;
    private readonly int _rows;
    private readonly int _cols;

    public TwoDimensionalWorldWithoutWraparoundProcessor(TwoDimensionalWorld twoDimensionalWorld, TwoDimensionalWorldDisplayBuilder twoDimensionalWorldDisplayBuilder)
    {
        _twoDimensionalWorld = twoDimensionalWorld;
        _twoDimensionalWorldDisplayBuilder = twoDimensionalWorldDisplayBuilder;
        _rows = _twoDimensionalWorld.GetWorldDimensions()[0];
        _cols = _twoDimensionalWorld.GetWorldDimensions()[1];
    }
    
    private void GetNextGeneration() 
    {
        _oldGeneration = _twoDimensionalWorld.ArrayOfCells;
        _newGeneration = new Cell[_rows, _cols];
        
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                var currentCell = _oldGeneration[row, col];
                var numberOfAliveNeighbours = GetNumberOfAliveNeighbours(row, col);
   
                if (currentCell.isCellAlive() && numberOfAliveNeighbours < Constants.Constants.TwoDimensionalWorldLowerThreshold)
                {
                    _newGeneration[row,col] = new Cell(CellState.Dead);
                }
                else if (currentCell.isCellAlive() && numberOfAliveNeighbours > Constants.Constants.TwoDimensionalWorldUpperThreshold)
                {
                    _newGeneration[row, col] = new Cell(CellState.Dead);
                }
                else if (!currentCell.isCellAlive() && numberOfAliveNeighbours == Constants.Constants.TwoDimensionalWorldUpperThreshold)
                {
                    _newGeneration[row,col] = new Cell(CellState.Alive);
                }
                else
                {
                    _newGeneration[row, col] = new Cell(currentCell.GetCellState());
                }
            }
        }
    }
private int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)  
        {
            for (var j= -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                if (currentCellRow + i < 0 || currentCellRow + i >= _rows) continue;  // Out of bounds
                if (currentCellCol + j < 0 || currentCellCol + j >= _cols) continue;  // Out of bounds
                
                var neighbourRow = currentCellRow + i;
                var neighbourCol = currentCellCol + j;
                aliveNeighbours += _oldGeneration[neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;
            }
        }
        return aliveNeighbours;
    }

    public bool IsWorldStable()
    {
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                if (_oldGeneration[row, col].GetCellState() != _newGeneration[row, col].GetCellState())
                {
                    return false;
                }
            }
        }

        return true;
    }
    public string BuildWorld()
    {
        return _twoDimensionalWorldDisplayBuilder.Build(_twoDimensionalWorld);
    }

    public void Tick()
    {
        GetNextGeneration();
        _twoDimensionalWorld.ArrayOfCells = _newGeneration;
    }
}