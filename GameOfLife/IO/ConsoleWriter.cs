using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class ConsoleWriter : IWriter
{
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

    // public string BuildWorld(IWorld world)
    // {
    //     return _worldDisplayBuilder.Build(world);
    // }
}