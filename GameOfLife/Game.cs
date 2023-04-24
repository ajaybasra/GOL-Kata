using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class Game
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly IWorldProcessorFactory _worldProcessorFactory;
    private IWorldProcessor _worldProcessor;
    private readonly ArgumentParser _argumentParser;
    public Game(IReader reader, IWriter writer, IWorldProcessorFactory worldProcessorFactory, ArgumentParser argumentParser)
    {
        _reader = reader;
        _writer = writer;
        _worldProcessorFactory = worldProcessorFactory;
        _argumentParser = argumentParser;
    }

    public void Initialize()
    {
        _worldProcessor = _argumentParser.GetChosenGameVersion() == 2
            ? _worldProcessorFactory.CreateTwoDimensionalWorldProcessor(_argumentParser.GetWorldDimensions())
            : _worldProcessorFactory.CreateThreeDimensionalWorldProcessor(_argumentParser.GetWorldDimensions());
        _writer.WriteLine(GameMessageBuilder.IntroMessage());
     Play();
    }

    private void Play()
    {
        DisplayWorld();
        
        while (true)
        {
            Thread.Sleep(500);
            _worldProcessor.Tick();
            if (_worldProcessor.IsWorldStable())
            {
                break;
            }
            DisplayWorld();
        }
    }

    private void DisplayWorld()
    {        
        var worldToDisplay = _worldProcessor.BuildWorld();
        _writer.WriteLine(worldToDisplay);
    }
}