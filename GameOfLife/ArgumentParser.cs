using GameOfLife.Interfaces;
using GameOfLife.IO;

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
        var gameVersion = _programArguments[1];
        Validator.ValidateGameVersion(gameVersion);
        
        var chosenGameVersion = int.Parse(gameVersion);
        return chosenGameVersion;
    }

    public List<int> GetWorldDimensions()
    {
        var rawWorldDimensions = new List<string>();
        rawWorldDimensions.AddRange(_programArguments.Skip(2).Select(arg => arg));
        Validator.ValidateWorldDimensions(GetChosenGameVersion(), rawWorldDimensions);
        
        var worldDimensions = new List<int>();
        worldDimensions.AddRange(_programArguments.Skip(2).Select(arg => int.Parse(arg)));
        return worldDimensions;
    }
}