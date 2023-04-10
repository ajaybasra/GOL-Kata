using GameOfLife.Interfaces;

namespace GameOfLife;

public class Game
{
    private IReader _reader;
    private IWriter _writer;
    private IWorld _world;
    private WorldProcessor _worldProcessor;

    public Game(IReader reader, IWriter writer, IWorld world, WorldProcessor worldProcessor)
    {
        _reader = reader;
        _writer = writer;
        _world = world;
        _worldProcessor = worldProcessor;
    }

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void Play()
    {
        throw new NotImplementedException();
    }
}