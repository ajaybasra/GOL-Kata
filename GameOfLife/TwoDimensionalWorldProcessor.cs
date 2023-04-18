using GameOfLife.Enums;
using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorldProcessor : IWorldProcessor
{
    public Object GetNextGeneration(IWorld world)
    {
        var rows = world.GetWorldDimensions()[0];
        var cols = world.GetWorldDimensions()[1];
        var oldGeneration = (Cell[,])world.GetArrayOfCells();
        var newGeneration = new Cell[rows, cols];
        
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var currentCell = oldGeneration[row, col];
                var numberOfAliveNeighbours = GetNumberOfAliveNeighbours(row, col, oldGeneration, rows, cols);
   
                if (currentCell.isCellAlive() && numberOfAliveNeighbours < 2)
                {
                    newGeneration[row,col] = new Cell(CellState.Dead);
                }
                else if (currentCell.isCellAlive() && numberOfAliveNeighbours > 3)
                {
                    newGeneration[row, col] = new Cell(CellState.Dead);
                }
                else if (!currentCell.isCellAlive() && numberOfAliveNeighbours == 3)
                {
                    newGeneration[row,col] = new Cell(CellState.Alive);
                }
                else
                {
                    newGeneration[row, col] = new Cell(currentCell.GetCellState());
                }
            }
        }
        return newGeneration;
    }

    public int Mod(int x, int m) // works for negative numbers too unlike % operator
    {
        var r = x % m;
        return r<0 ? r+m : r;
    }

    private int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol, Cell[,] oldGeneration, int rows, int cols)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)
        {
            for (var j= -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                var neighbourRow = Mod((currentCellRow + i), rows);
                var neighbourCol = Mod((currentCellCol + j), cols);
                aliveNeighbours += oldGeneration[neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;

            }
        }
        return aliveNeighbours;
    }

    public bool IsWorldStable(Object oldGeneration, Object newGeneration, List<int> worldDimensions)
    {
        var oldGenerationArray = (Cell[,])oldGeneration;
        var newGenerationArray = (Cell[,])newGeneration;
        var rows = worldDimensions[0];
        var cols = worldDimensions[1];
        
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (oldGenerationArray[row, col].GetCellState() != newGenerationArray[row, col].GetCellState())
                {
                    return false;
                }
            }
        }

        return true;
    }
}