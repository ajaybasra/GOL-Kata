namespace GameOfLife.Interfaces;

public interface IWorldFactory
{
    TwoDimensionalWorldProcessor CreateTwoDimensionalWorld(int rows, int cols);
    ThreeDimensionalWorldProcessor CreateThreeDimensionalWorld(int aisles, int rows, int cols);
}