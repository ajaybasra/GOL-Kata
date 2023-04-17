namespace GameOfLife.Interfaces;

public interface IWorldProcessor
{
    Cell[,] GetNextGeneration();
}