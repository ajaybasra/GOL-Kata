namespace GameOfLife.Interfaces;

public interface IReader
{
    int Read();
    string ReadLine();
    ConsoleKeyInfo ReadKey();
}