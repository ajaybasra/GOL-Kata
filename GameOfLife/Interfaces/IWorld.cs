namespace GameOfLife.Interfaces;

public interface IWorld
{
    void RandomizeWorld();
    List<int> GetWorldDimensions();
    object GetArrayOfCells();
}