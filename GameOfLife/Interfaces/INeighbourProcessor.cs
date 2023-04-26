namespace GameOfLife.Interfaces;

public interface INeighbourProcessor
{
    int GetNumberOfAliveNeighbours(int currentCellRow, int currentCellCol, int rows, int cols, Cell[,] oldGeneration);
}