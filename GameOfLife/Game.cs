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
        var worldToDisplay = _writer.BuildWorld(_world);
        _writer.WriteLine(worldToDisplay);
        var worldIsNotStable = true;
        
        while (worldIsNotStable)
        {
            Thread.Sleep(500);
            var oldGeneration = _world.GetArrayOfCells();
            var newGeneration = _worldProcessor.GetNextGeneration(_world);
            if (_worldProcessor.IsWorldStable(oldGeneration, newGeneration, _world.GetWorldDimensions()))
            {
                worldIsNotStable = false;
            }
            _world.UpdateArrayOfCells(newGeneration);
            worldToDisplay = _writer.BuildWorld(_world);
            _writer.WriteLine(worldToDisplay);

        }

    }
}