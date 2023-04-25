namespace GameOfLife.Interfaces;

public interface IWorldProcessorFactory
{
    TwoDimensionalWorldProcessor CreateTwoDimensionalWorldProcessor(List<int> worldDimensions);

    TwoDimensionalWorldWithoutWraparoundProcessor CreateTwoDimensionalWorldWithoutWraparoundProcessor(List<int> worldDimensions);
    ThreeDimensionalWorldProcessor CreateThreeDimensionalWorldProcessor(List<int> worldDimensions);
}