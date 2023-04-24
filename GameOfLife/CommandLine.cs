using GameOfLife.Interfaces;

namespace GameOfLife;

public class Command : ICommandLine

{
    public string[] GetCommandLineArgs()
    {
        return Environment.GetCommandLineArgs();
    }
}