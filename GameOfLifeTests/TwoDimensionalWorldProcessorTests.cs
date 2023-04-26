using GameOfLife;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.IO;
using Moq;

namespace GameOfLifeTests;

public class TwoDimensionalWorldProcessorTests
{
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly TwoDimensionalWorldProcessor _twoDimensionalWorldProcessor;
    private readonly TwoDimensionalWorldNeighbourProcessor _twoDimensionalWorldNeighbourProcessor;

    public TwoDimensionalWorldProcessorTests()
    {
        _twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
        _twoDimensionalWorldNeighbourProcessor = new TwoDimensionalWorldNeighbourProcessor();
        _twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(_twoDimensionalWorld, new TwoDimensionalWorldDisplayBuilder(), _twoDimensionalWorldNeighbourProcessor);
    }
    
    [Fact]
    public void IsWorldStable_ReturnsFalse_WhenNextGenerationIsDifferent()
    {
        _twoDimensionalWorld.RandomizeWorld();
        _twoDimensionalWorldProcessor.Tick();
        
        Assert.False(_twoDimensionalWorldProcessor.IsWorldStable());
    }
    
    [Fact]
    public void IsWorldStable_ReturnsTrue_WhenNextGenerationIsSame()
    {
        _twoDimensionalWorldProcessor.Tick();
        
        Assert.True(_twoDimensionalWorldProcessor.IsWorldStable());
    }

}