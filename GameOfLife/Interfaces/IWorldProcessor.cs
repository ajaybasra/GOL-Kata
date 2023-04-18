namespace GameOfLife.Interfaces;

public interface IWorldProcessor
{
    Object GetNextGeneration(IWorld world);
    bool IsWorldStable(Object oldGeneration, Object newGeneration, List<int> worldDimensions);
}