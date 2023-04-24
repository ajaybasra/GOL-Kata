using GameOfLife.Interfaces;

namespace GameOfLife;

public class ArgumentParser
{
    private readonly string[] _programArguments;

    public ArgumentParser(ICommandLine commandLine)
    {
        _programArguments = commandLine.GetCommandLineArgs();
    }
    
    public int GetChosenGameVersion()
    {
        var chosenGameVersion = int.Parse(_programArguments[1]);
        return chosenGameVersion;
    }

    public List<int> GetWorldDimensions()
    {
        var worldDimensions = new List<int>{};
        worldDimensions.AddRange(_programArguments.Skip(2).Select(arg => int.Parse(arg)));

        return worldDimensions;
    }
}