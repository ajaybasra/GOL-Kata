namespace GameOfLife.Interfaces;

public interface IWorldProcessor
{
    bool IsWorldStable();

    string BuildWorld();
    
    void Tick();

}