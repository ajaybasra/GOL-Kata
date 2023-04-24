using GameOfLife.Interfaces;

namespace GameOfLife;

public class CommandLine : ICommandLine

{
    public string[] GetCommandLineArgs()
    {
        return Environment.GetCommandLineArgs();
    }
}