using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorld : IWorld
{
    private int _rows;
    private int _cols;
    private Cell[,] _arrayOfCells;

    public TwoDimensionalWorld(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
    }

    public void CreateDeadWorld(int rows, int cols)
    {
        throw new NotImplementedException();
    }

    public void RandomizeWorld()
    {
        throw new NotImplementedException();
    }
    public List<int> GetWorldDimensions()
    {
        throw new NotImplementedException();
    }

    public object GetArrayOfCells()
    {
        throw new NotImplementedException();
    }
}