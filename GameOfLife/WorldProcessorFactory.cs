using GameOfLife.Interfaces;
using GameOfLife.IO;

namespace GameOfLife;

public class WorldProcessorFactory : IWorldProcessorFactory
{
    public TwoDimensionalWorldProcessor CreateTwoDimensionalWorldProcessor(List<int> worldDimensions)
    {
        var rows = worldDimensions[0];
        var cols = worldDimensions[1];
        var rng = new RNG();
        var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
        var twoDimensionalWorld = new TwoDimensionalWorld(rows, cols, rng);
        twoDimensionalWorld.RandomizeWorld();
        var twoDimensionalWorldNeighbourProcessor = new TwoDimensionalWorldNeighbourProcessor();
        var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(twoDimensionalWorld, twoDimensionalWorldDisplayBuilder, twoDimensionalWorldNeighbourProcessor);
        return twoDimensionalWorldProcessor;
    }

    public TwoDimensionalWorldProcessor CreateTwoDimensionalWorldProcessorWithoutWraparound(List<int> worldDimensions)
    {
        var rows = worldDimensions[0];
        var cols = worldDimensions[1];
        var rng = new RNG();
        var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
        var twoDimensionalWorld = new TwoDimensionalWorld(rows, cols, rng);
        twoDimensionalWorld.RandomizeWorld();
        var twoDimensionalWorldWithoutWraparoundNeighbourProcessor = new TwoDimensionalWorldWithoutWraparoundNeighbourProcessor();
        var twoDimensionalWorldProcessorWithoutWraparound = new TwoDimensionalWorldProcessor(twoDimensionalWorld, twoDimensionalWorldDisplayBuilder, twoDimensionalWorldWithoutWraparoundNeighbourProcessor);
        return twoDimensionalWorldProcessorWithoutWraparound;
    }

    public ThreeDimensionalWorldProcessor CreateThreeDimensionalWorldProcessor(List<int> worldDimensions)
    {
        var aisles = worldDimensions[0];
        var rows = worldDimensions[1];
        var cols = worldDimensions[2];
        var rng = new RNG();
        var threeDimensionalWorldDisplayBuilder = new ThreeDimensionalWorldDisplayBuilder();
        var threeDimensionalWorld = new ThreeDimensionalWorld(aisles, rows, cols, rng);
        threeDimensionalWorld.RandomizeWorld();
        var threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor(threeDimensionalWorld, threeDimensionalWorldDisplayBuilder);
        return threeDimensionalWorldProcessor;
    }
}