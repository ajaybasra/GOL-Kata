using System.Collections;
using GameOfLife.Enums;
using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorld : IWorld
{
    private readonly int _rows;
    private readonly int _cols;
    private Cell[,] _arrayOfCells;
    private readonly IRandomNumberGenerator _randomNumberGenerator;

    public TwoDimensionalWorld(int rows, int cols, IRandomNumberGenerator randomNumberGenerator)
    {
        _rows = rows;
        _cols = cols;
        _randomNumberGenerator = randomNumberGenerator;
        _arrayOfCells = new Cell[_rows, _cols];
        CreateDeadWorld(_rows, _cols);
    }

    private void CreateDeadWorld(int rows, int cols)
    {
        for (var i = 0; i < rows ; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                _arrayOfCells[i, j] = new Cell(CellState.Dead);
            }
        }
    }

    public void RandomizeWorld()
    {
        var randomizedWorld = new Cell[_rows, _cols];
        
        for (var i = 0; i < _rows ; i++)
        {
            for (var j = 0; j < _cols; j++)
            {
                randomizedWorld[i, j] = _randomNumberGenerator.GetRandomNumber() == 0 ? new Cell(CellState.Dead) : new Cell(CellState.Alive);
            }
        }
        _arrayOfCells = randomizedWorld;
    }
    public List<int> GetWorldDimensions()
    {
        var worldDimensions = new List<int> { _rows, _cols };
        return worldDimensions;
    }

    public Cell[,] GetArrayOfCells()
    {
        return _arrayOfCells;
    }
    public void UpdateArrayOfCells(Cell[,] newArrayOfCells)
    {
        for (var i = 0; i < _rows ; i++)
        {
            for (var j = 0; j < _cols; j++)
            {
                _arrayOfCells[i, j] = newArrayOfCells[i, j];
            }
        }
    }
}