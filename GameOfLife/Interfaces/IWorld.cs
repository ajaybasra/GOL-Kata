using System.Collections;

namespace GameOfLife.Interfaces;

public interface IWorld
{
    void RandomizeWorld();
    List<int> GetWorldDimensions();
    Cell[,] GetArrayOfCells();

    void UpdateArrayOfCells(Cell[,] newArrayOfCells);
}