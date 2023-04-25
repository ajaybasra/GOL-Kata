namespace GameOfLife.IO;

public static class Validator
{
    public static void ValidateGameVersion(string gameVersion)
    {
        var isNumeric = int.TryParse(gameVersion, out _);
        
        if (!isNumeric)
        {
            throw new ArgumentException("\nYou must enter an integer for the game version. Please try again.");
        }
    }

    public static void ValidateWorldDimensions(int gameVersion, List<string> worldDimensions)
    {
        ValidateWorldDimensionsLength(gameVersion, worldDimensions);
        ValidateWorldDimensionsAreOfTypeInt(worldDimensions);
    }
    
    private static void ValidateWorldDimensionsLength(int gameVersion, List<string> worldDimensions)
    {
        if (gameVersion == 2 && worldDimensions.Count != 2)
        {
            throw new ArgumentException("\nYou must enter 2 world dimensions for a 2D world. Please try again.");
        }
        if (gameVersion == 3 && worldDimensions.Count != 3)
        {
            throw new ArgumentException("\nYou must enter 3 world dimensions for a 3D world. Please try again.");
        }

        if (gameVersion != 2 && gameVersion != 3 && worldDimensions.Count != 2)
        {
            throw new ArgumentException("\nYou must enter 2 world dimensions for a default 2D world without wraparound. Please try again.");
        }
    }

    private static void ValidateWorldDimensionsAreOfTypeInt(List<string> worldDimensions)
    {
        if (worldDimensions.Any(dimension=> int.TryParse(dimension, out _) is false))
        {
            throw new ArgumentException("\nDimension values must be of type int. Please try again.");
        }
    }
}