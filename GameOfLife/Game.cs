using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class Game
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly IWorldProcessorFactory _worldProcessorFactory;
    private IWorldProcessor _worldProcessor;
    public Game(IReader reader, IWriter writer, IWorldProcessorFactory worldProcessorFactory)
    {
        _reader = reader;
        _writer = writer;
        _worldProcessorFactory = worldProcessorFactory;
    }

    public void Initialize()
    {
        _worldProcessor = ArgumentParser.GetChosenGameVersion() == 2
            ? _worldProcessorFactory.CreateTwoDimensionalWorldProcessor(ArgumentParser.GetWorldDimensions())
            : _worldProcessorFactory.CreateThreeDimensionalWorldProcessor(ArgumentParser.GetWorldDimensions());
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