using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class TwoDimensionalWorldProcessor : IWorldProcessor
{
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly TwoDimensionalWorldDisplayBuilder _twoDimensionalWorldDisplayBuilder;
    private readonly INeighbourProcessor _neighbourProcessor;
    private Cell[,] _oldGeneration;
    private Cell[,] _newGeneration;
    private readonly int _rows;
    private readonly int _cols;
    public TwoDimensionalWorldProcessor(TwoDimensionalWorld twoDimensionalWorld, TwoDimensionalWorldDisplayBuilder twoDimensionalWorldDisplayBuilder, INeighbourProcessor neighbourProcessor)
    {
        _twoDimensionalWorld = twoDimensionalWorld;
        _twoDimensionalWorldDisplayBuilder = twoDimensionalWorldDisplayBuilder;
        _neighbourProcessor = neighbourProcessor;
        _rows = _twoDimensionalWorld.GetWorldDimensions()[0];
        _cols = _twoDimensionalWorld.GetWorldDimensions()[1];
    }
    private void GetNextGeneration() 
    {
        _oldGeneration = _twoDimensionalWorld.ArrayOfCells;
        _newGeneration = new Cell[_rows, _cols];
        
        for (var row = 0; row < _rows; row++) //can also computer # of neighbours in a more optimized fashion
        {
            for (var col = 0; col < _cols; col++)
            {
                var currentCell = _oldGeneration[row, col];
                var numberOfAliveNeighbours = _neighbourProcessor.GetNumberOfAliveNeighbours(row, col, _rows, _cols, _oldGeneration);
   
                if (currentCell.IsCellAlive() && numberOfAliveNeighbours < Constants.Constants.TwoDimensionalWorldLowerThreshold)
                {
                    _newGeneration[row,col] = new Cell(CellState.Dead);
                }
                else if (currentCell.IsCellAlive() && numberOfAliveNeighbours > Constants.Constants.TwoDimensionalWorldUpperThreshold)
                {
                    _newGeneration[row, col] = new Cell(CellState.Dead);
                }
                else if (!currentCell.IsCellAlive() && numberOfAliveNeighbours == Constants.Constants.TwoDimensionalWorldUpperThreshold)
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