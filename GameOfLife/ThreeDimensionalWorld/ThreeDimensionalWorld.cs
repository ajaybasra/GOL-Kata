using System.Data;
using GameOfLife.Enums;
using GameOfLife.Interfaces;

namespace GameOfLife;

public class ThreeDimensionalWorld : IWorld
{
    private readonly int _aisles;
    private readonly int _rows;
    private readonly int _cols;
    public Cell[,,] ArrayOfCells { get; set; }
    private readonly IRandomNumberGenerator _randomNumberGenerator;

    public ThreeDimensionalWorld(int aisles, int rows, int cols, IRandomNumberGenerator randomNumberGenerator)
    {
        _aisles = aisles;
        _rows = rows;
        _cols = cols;
        _randomNumberGenerator = randomNumberGenerator;
        ArrayOfCells = new Cell[_aisles, _rows, _cols];
        CreateDeadWorld(_aisles, _rows, _cols);
    } 
    
    private void CreateDeadWorld(int aisles, int rows, int cols)
    {
        for (var i = 0; i < aisles ; i++)
        {
            for (var j = 0; j < rows; j++)
            {
                for (var k = 0; k < cols; k++)
                {
                    ArrayOfCells[i, j, k] = new Cell(CellState.Dead);
                }
            }
        }
    }
    
    public void RandomizeWorld()
    {
        var randomizedWorld = new Cell[_aisles, _rows, _cols];
        
        for (var i = 0; i < _aisles ; i++)
        {
            for (var j = 0; j < _rows; j++)
            {
                for (var k = 0; k < _cols; k++)
                {
                    randomizedWorld[i, j, k] = _randomNumberGenerator.GetRandomNumber() == 0 ? new Cell(CellState.Dead) : new Cell(CellState.Alive);
                }
            }
        }
        ArrayOfCells = randomizedWorld;
    }
    
    public List<int> GetWorldDimensions()
    {
        var worldDimensions = new List<int> { _aisles, _rows, _cols };
        return worldDimensions;
    }

}