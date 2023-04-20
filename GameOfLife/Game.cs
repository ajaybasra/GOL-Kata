using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class Game
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly IWorld _world;
    private readonly IWorldProcessor _worldProcessor;
    public Game(IReader reader, IWriter writer, IWorld world, IWorldProcessor worldProcessor)
    {
        _reader = reader;
        _writer = writer;
        _world = world;
        _worldProcessor = worldProcessor;
    }

    public void Initialize()
    {
     _writer.WriteLine(GameMessageBuilder.IntroMessage());
     Play();
    }

    private void Play()
    {
        _world.RandomizeWorld();
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