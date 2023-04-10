using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class ConsoleWriter : IWriter
{
    private readonly IWorldBuilder _worldBuilder;
    public ConsoleWriter(IWorldBuilder worldBuilder)
    {
        _worldBuilder = worldBuilder;
    }
    public void Write(string output)
    {
        Console.Write(output);
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public void Clear()
    {
        Console.Clear();
    }

    public string BuildWorld(IWorld world)
    {
        return _worldBuilder.Build(world);
    }
}