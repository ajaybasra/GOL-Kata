using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class WorldFactory : IWorldFactory
{
    public TwoDimensionalWorldProcessor CreateTwoDimensionalWorld(int rows, int cols)
    {
        var rng = new RNG();
        var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
        var twoDimensionalWorld = new TwoDimensionalWorld(rows, cols, rng);
        var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(twoDimensionalWorld, twoDimensionalWorldDisplayBuilder);
        return twoDimensionalWorldProcessor;
    }

    public ThreeDimensionalWorldProcessor CreateThreeDimensionalWorld(int aisles, int rows, int cols)
    {
        var rng = new RNG();
        var threeDimensionalWorldDisplayBuilder = new ThreeDimensionalWorldDisplayBuilder();
        var threeDimensionalWorld = new ThreeDimensionalWorld(aisles, rows, cols, rng);
        var threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor(threeDimensionalWorld, threeDimensionalWorldDisplayBuilder);
        return threeDimensionalWorldProcessor;
    }
}