using GameOfLife;
using GameOfLife.Interfaces;
using GameOfLife.IO;
using Moq;

namespace GameOfLifeTests;

public class ThreeDimensionalWorldDisplayBuilderTests
{
    private readonly ThreeDimensionalWorldDisplayBuilder _threeDimensionalWorldDisplayBuilder;
    private readonly ThreeDimensionalWorld _threeDimensionalWorld;
    private readonly ThreeDimensionalWorld _threeDimensionalWorldWithMockedRNG;
    private readonly Mock<IRandomNumberGenerator> _mockRNG;

    public ThreeDimensionalWorldDisplayBuilderTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _threeDimensionalWorldWithMockedRNG = new ThreeDimensionalWorld(2,5, 5, _mockRNG.Object);
        _threeDimensionalWorld = new ThreeDimensionalWorld(2,5, 5, new RNG());
        _threeDimensionalWorldDisplayBuilder = new ThreeDimensionalWorldDisplayBuilder();
    }
    
    [Fact]
    public void Build_ReturnsCorrectString_ForInitialDeadWorld()
    {
        var expected = "World number 1:\n.....\n.....\n.....\n.....\n.....\n_____\nWorld number 2:\n.....\n.....\n.....\n.....\n.....\n_____\n";

        var actual = _threeDimensionalWorldDisplayBuilder.Build(_threeDimensionalWorld);

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
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(0)
            .Returns(1);
    
        var expected = "World number 1:\n.X.XX\n....X\n.....\nXXXXX\n.....\n_____\nWorld number 2:\nXXX.X\n.....\n.....\n.....\n.....\n_____\n";

        _threeDimensionalWorldWithMockedRNG.RandomizeWorld();
        var actual = _threeDimensionalWorldDisplayBuilder.Build(_threeDimensionalWorldWithMockedRNG);

        Assert.Equal(expected, actual);
    }
}