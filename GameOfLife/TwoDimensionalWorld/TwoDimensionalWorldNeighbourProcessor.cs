using GameOfLife.Interfaces;

namespace GameOfLife;

public class TwoDimensionalWorldNeighbourProcessor : INeighbourProcessor
{
    public int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol, int rows, int cols, Cell[,] oldGeneration)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)  
        {
            for (var j= -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                var neighbourRow = Mod((currentCellRow + i), rows);
                var neighbourCol = Mod((currentCellCol + j), cols);
                aliveNeighbours += oldGeneration[neighbourRow, neighbourCol].IsCellAlive() ? 1 : 0;
            }
        }
        return aliveNeighbours;
    }
    
    private int Mod(int x, int m) // works for negative numbers too unlike % operator
    {
        var r = x % m;
        return r<0 ? r+m : r;
    }
}