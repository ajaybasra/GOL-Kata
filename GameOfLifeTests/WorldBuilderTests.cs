using GameOfLife;
using GameOfLife.Interfaces;
using GameOfLife.IO;
using Moq;

namespace GameOfLifeTests;

public class WorldBuilderTests
{
    private readonly WorldBuilder _worldBuilder;
    private readonly TwoDimensionalWorld _twoDimensionalWorld;
    private readonly TwoDimensionalWorld _twoDimensionalWorldWithMockedRNG;
    private readonly Mock<IRandomNumberGenerator> _mockRNG;

    public WorldBuilderTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _twoDimensionalWorldWithMockedRNG = new TwoDimensionalWorld(5, 5, _mockRNG.Object);
        _twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
        _worldBuilder = new WorldBuilder();
    }

    [Fact]
    public void Build_ReturnsCorrectString_ForInitialDeadWorld()
    {
        var expected = ".....\n.....\n.....\n.....\n.....\n";

        var actual = _worldBuilder.Build(_twoDimensionalWorld);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Build_ReturnsCorrectString_ForRandomizedWorld()
    {
        _mockRNG.SetupSequence(x => x.GetRandomNumber())
            .Returns(0)
            .Returns(1)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(1);
        var expected = ".X.XX\n....X\n.....\nXXXXX\n.....\n";

        _twoDimensionalWorldWithMockedRNG.RandomizeWorld();
        var actual = _worldBuilder.Build(_twoDimensionalWorldWithMockedRNG);

        Assert.Equal(expected, actual);
    }
    
    
}