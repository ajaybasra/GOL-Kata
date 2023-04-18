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
        var expected = ".....\n.....\n.....\n.....\n.....\n.....\n.....\n.....\n.....\n.....\n";

        var actual = _threeDimensionalWorldDisplayBuilder.Build(_threeDimensionalWorld);

        Assert.Equal(expected, actual);
    }
}