namespace GameOfLifeTests;

public class FakeArgumentParser
{
    private static readonly string[] ProgramArguments = { "pathname", "2", "5", "5" };

    public static int GetChosenGameVersion()
    {
        var chosenGameVersion = int.Parse(ProgramArguments[1]);
        return chosenGameVersion;
    }

    public static List<int> GetWorldDimensions()
    {
        var worldDimensions = new List<int>{};
        worldDimensions.AddRange(ProgramArguments.Skip(2).Select(arg => int.Parse(arg)));

        return worldDimensions;
    }
}