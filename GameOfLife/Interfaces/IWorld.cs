using System.Collections;

namespace GameOfLife.Interfaces;

public interface IWorld
{
    void RandomizeWorld();
    List<int> GetWorldDimensions();
    Object GetArrayOfCells();
    void UpdateArrayOfCells(Object newArrayOfCells);
}