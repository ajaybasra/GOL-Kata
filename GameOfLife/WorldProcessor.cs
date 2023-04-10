namespace GameOfLife;

public class WorldProcessor
{
    private Cell[,] _currentGeneration;

    public WorldProcessor(Cell[,] currentGeneration)
    {
        _currentGeneration = currentGeneration;
    }

    public Cell[,] GetNextGeneration()
    {
        throw new NotImplementedException();
    }
}