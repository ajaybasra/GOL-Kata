using GameOfLife.Interfaces;

namespace GameOfLife;

public class Game
{
    private IReader _reader;
    private IWriter _writer;
    private IWorld _world;
    private TwoDimensionalWorldProcessor _twoDimensionalWorldProcessor;

    public Game(IReader reader, IWriter writer, IWorld world, TwoDimensionalWorldProcessor twoDimensionalWorldProcessor)
    {
        _reader = reader;
        _writer = writer;
        _world = world;
        _twoDimensionalWorldProcessor = twoDimensionalWorldProcessor;
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