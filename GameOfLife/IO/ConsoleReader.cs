using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class ConsoleReader : IReader
{
    public int Read()
    {
        return Console.Read();
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey(true); // set to true so that key isn't displayed to console
    }
}