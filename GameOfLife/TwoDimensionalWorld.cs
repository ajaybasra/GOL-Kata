using System.Collections;
using GameOfLife.Enums;
using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorld : IWorld
{
    private int _rows;
    private int _cols;
    private readonly Cell[,] _arrayOfCells;

    public TwoDimensionalWorld(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        _arrayOfCells = new Cell[rows, cols];
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
        throw new NotImplementedException();
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
}