using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class Game
{
    private IReader _reader;
    private IWriter _writer;
    private IWorld _world;
    // private TwoDimensionalWorldProcessor _twoDimensionalWorldProcessor;

    public Game(IReader reader, IWriter writer, IWorld world)
    {
        _reader = reader;
        _writer = writer;
        _world = world;
        // _twoDimensionalWorldProcessor = twoDimensionalWorldProcessor;
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
        bool worldIsNotStable = true;
        
        while (worldIsNotStable)
        {
            TwoDimensionalWorldProcessor twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(_world);
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