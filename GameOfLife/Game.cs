using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class Game
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly IWorld _world;
    public Game(IReader reader, IWriter writer, IWorld world)
    {
        _reader = reader;
        _writer = writer;
        _world = world;
    }

    public void Initialize()
    {
     _writer.WriteLine(GameMessageBuilder.IntroMessage());
     Play();
    }

    private void Play()
    {
        _world.RandomizeWorld();
        var worldToDisplay = _writer.BuildWorld(_world);
        _writer.WriteLine(worldToDisplay);
        var worldIsNotStable = true;
        
        while (worldIsNotStable)
        {
            Thread.Sleep(500);
            var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(_world);
            _world.UpdateArrayOfCells(twoDimensionalWorldProcessor.GetNextGeneration());
            worldToDisplay = _writer.BuildWorld(_world);
            _writer.WriteLine(worldToDisplay);
            if (twoDimensionalWorldProcessor.IsWorldStable())
            {
                worldIsNotStable = false;
            }
        }

    }
}