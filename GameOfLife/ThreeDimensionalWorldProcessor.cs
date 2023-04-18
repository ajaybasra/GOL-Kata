using GameOfLife.Interfaces;

namespace GameOfLife;

public class ThreeDimensionalWorldProcessor : IWorldProcessor
{
    public object GetNextGeneration(IWorld world)
    {
        var aisles = world.GetWorldDimensions()[0];
        var rows = world.GetWorldDimensions()[1];
        var cols = world.GetWorldDimensions()[2];
        var oldGeneration = (Cell[,,])world.GetArrayOfCells();
        var newGeneration = new Cell[aisles, rows, cols];

        for (var aisle = 0; aisle < aisles; aisle++) 
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var currentCell = oldGeneration[aisle, row, col];
                    var numberOfAliveNeighbours = GetNumberOfAliveNeighbours(aisle, row, col, oldGeneration, aisles, rows, cols);
                }
            }
        }
        throw new NotImplementedException();
    }

    private int Mod(int x, int m) // works for negative numbers too unlike % operator
    {
        var r = x % m;
        return r<0 ? r+m : r;
    }
    
    private int GetNumberOfAliveNeighbours(int currentCellAisle, int currentCellRow, int currentCellCol, Cell[,,] oldGeneration, int aisles, int rows, int cols)
    {
        var aliveNeighbours = 0;
        for (var i= -1; i <= 1; i++)
        {
            for (var j= -1; j <= 1; j++)
            {
                for (var k = -1; k < 1; k++)
                {
                    if (i == 0 && j == 0 && k == 0) continue;
                    var neighbourAisle = Mod( (currentCellAisle + i), aisles);
                    var neighbourRow = Mod((currentCellRow + j), rows);
                    var neighbourCol = Mod((currentCellCol + k), cols);
                    aliveNeighbours += oldGeneration[neighbourAisle, neighbourRow, neighbourCol].isCellAlive() ? 1 : 0;
                }
            }
        }
        return aliveNeighbours;
    }
    public bool IsWorldStable(object oldGeneration, object newGeneration, List<int> worldDimensions)
    {
        var oldGenerationArray = (Cell[,,])oldGeneration;
        var newGenerationArray = (Cell[,,])newGeneration;
        var aisles = worldDimensions[0];
        var rows = worldDimensions[1];
        var cols = worldDimensions[2];
        
        for (var i = 0; i < aisles ; i++)
        {
            for (var j = 0; j < rows; j++)
            {
                for (var k = 0; k < cols; k++)
                {
                    if (oldGenerationArray[i,j,k].GetCellState() != newGenerationArray[i,j,k].GetCellState())
                    {
                        return false;
                    }
                }
                    
            }
        }
        return true;
    }
}