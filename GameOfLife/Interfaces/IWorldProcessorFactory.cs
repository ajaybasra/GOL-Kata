namespace GameOfLife.Interfaces;

public interface IWorldProcessorFactory
{
    TwoDimensionalWorldProcessor CreateTwoDimensionalWorldProcessor(List<int> worldDimensions);

    TwoDimensionalWorldProcessor CreateTwoDimensionalWorldProcessorWithoutWraparound(List<int> worldDimensions);
    
    ThreeDimensionalWorldProcessor CreateThreeDimensionalWorldProcessor(List<int> worldDimensions);
}