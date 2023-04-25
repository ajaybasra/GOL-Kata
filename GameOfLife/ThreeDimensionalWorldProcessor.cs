using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class ThreeDimensionalWorldProcessor : IWorldProcessor
{
    private readonly ThreeDimensionalWorld _threeDimensionalWorld;
    private readonly ThreeDimensionalWorldDisplayBuilder _threeDimensionalWorldDisplayBuilder;
    private Cell[,,] _oldGeneration;
    private Cell[,,] _newGeneration;
    private readonly int _aisles;
    private readonly int _rows;
    private readonly int _cols;

    public ThreeDimensionalWorldProcessor(ThreeDimensionalWorld threeDimensionalWorld, ThreeDimensionalWorldDisplayBuilder threeDimensionalWorldDisplayBuilder)
    {
        _threeDimensionalWorld = threeDimensionalWorld;
        _threeDimensionalWorldDisplayBuilder = threeDimensionalWorldDisplayBuilder;
        _aisles = _threeDimensionalWorld.GetWorldDimensions()[0];
        _rows = _threeDimensionalWorld.GetWorldDimensions()[1];
        _cols = _threeDimensionalWorld.GetWorldDimensions()[2];
    }
    private void GetNextGeneration()
    {
        _oldGeneration = _threeDimensionalWorld.ArrayOfCells;
        _newGeneration = new Cell[_aisles, _rows, _cols];

        for (var aisle = 0; aisle < _aisles; aisle++) 
        {
            for (var row = 0; row < _rows; row++)
            {
                for (var col = 0; col < _cols; col++)
                {
                    var currentCell = _oldGeneration[aisle, row, col];
                    var numberOfAliveNeighbours = GetNumberOfAliveNeighbours(aisle, row, col);
                    
                    if (currentCell.isCellAlive() && numberOfAliveNeighbours < Constants.Constants.ThreeDimensionalWorldLowerThreshold)
                    {
                        _newGeneration[aisle, row, col] = new Cell(CellState.Dead);
                    }
                    else if (!currentCell.isCellAlive() && numberOfAliveNeighbours is > Constants.Constants.ThreeDimensionalWorldLowerThreshold and < Constants.Constants.ThreeDimensionalWorldUpperThreshold)
                    {
                        _newGeneration[aisle, row, col] = new Cell(CellState.Alive);
                    }
                    else
                    {
                        _newGeneration[aisle, row, col] = new Cell(currentCell.GetCellState());
                    }
                }
            }
        }
    }

    private int Mod(int x, int m) // works for negative numbers too unlike % operator
    {
        var r = x % m;
        return r<0 ? r+m : r;
    }
    
    private int GetNumberOfAliveNeighbours(int currentCellAisle, int currentCellRow, int currentCellCol)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)
        {
            for (var j= -1; j <= 1; j++)
            {
                for (var k = -1; k < 1; k++)
                {
                    if (i == 0 && j == 0 && k == 0) continue;
                    var neighbourAisle = Mod( (currentCellAisle + i), _aisles);
                    var neighbourRow = Mod((currentCellRow + j), _rows);
                    var neighbourCol = Mod((currentCellCol + k), _cols);
                    aliveNeighbours += _oldGeneration[neighbourAisle, neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;
                }
            }
        }
        return aliveNeighbours;
    }
    public bool IsWorldStable()
    {
        for (var i = 0; i < _aisles ; i++)
        {
            for (var j = 0; j <_rows; j++)
            {
                for (var k = 0; k < _cols; k++)
                {
                    if (_oldGeneration[i,j,k].GetCellState() != _newGeneration[i,j,k].GetCellState())
                    {
                        return false;
                    }
                }
                    
            }
        }
        return true;
    }
    
    public string BuildWorld()
    {
        return _threeDimensionalWorldDisplayBuilder.Build(_threeDimensionalWorld);
    }
    
    public void Tick()
    {
        GetNextGeneration();
        _threeDimensionalWorld.ArrayOfCells = _newGeneration;
    }
}