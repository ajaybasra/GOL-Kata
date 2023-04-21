using GameOfLife;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.IO;
using Moq;

namespace GameOfLifeTests;

public class ThreeDimensionalWorldProcessorTests
{
    private readonly ThreeDimensionalWorld _threeDimensionalWorld;
    private readonly ThreeDimensionalWorldProcessor _threeDimensionalWorldProcessor;

    public ThreeDimensionalWorldProcessorTests()
    {
        _threeDimensionalWorld = new ThreeDimensionalWorld(2, 5, 5, new RNG());
        _threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor(_threeDimensionalWorld, new ThreeDimensionalWorldDisplayBuilder());
    }
    
    [Fact]
    public void IsWorldStable_ReturnsFalse_WhenNextGenerationIsDifferent()
    {
        _threeDimensionalWorld.RandomizeWorld();
        _threeDimensionalWorldProcessor.Tick();
        
        Assert.False(_threeDimensionalWorldProcessor.IsWorldStable());
    }
    
    [Fact]
    public void IsWorldStable_ReturnsTrue_WhenNextGenerationIsSame()
    {
        _threeDimensionalWorldProcessor.Tick();
        
        Assert.True(_threeDimensionalWorldProcessor.IsWorldStable());
    }
}