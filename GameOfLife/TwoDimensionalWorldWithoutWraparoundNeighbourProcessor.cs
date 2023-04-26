using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorldWithoutWraparoundNeighbourProcessor : INeighbourProcessor
{
    public int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol, int rows, int cols, Cell[,] oldGeneration)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)  
        {
            for (var j= -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                if (currentCellRow + i < 0 || currentCellRow + i >= rows) continue;  // Out of bounds
                if (currentCellCol + j < 0 || currentCellCol + j >= cols) continue;  // Out of bounds
                
                var neighbourRow = currentCellRow + i;
                var neighbourCol = currentCellCol + j;
                aliveNeighbours += oldGeneration[neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;
            }
        }
        return aliveNeighbours;
    }
}