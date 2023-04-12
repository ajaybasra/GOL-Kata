using System.Collections;

namespace GameOfLife.Interfaces;

public interface IWorld
{
    Cell[,] GetRandomizedWorld();
    List<int> GetWorldDimensions();
    Cell[,] GetArrayOfCells();
}