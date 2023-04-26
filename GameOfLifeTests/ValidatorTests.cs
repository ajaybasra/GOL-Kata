using GameOfLife.IO;

namespace GameOfLifeTests;

public class ValidatorTests
{
    [Theory]
    [InlineData("a")]
    [InlineData("")]
    [InlineData("!")]
    [InlineData("?")]
    [InlineData(" ")]
    [InlineData("5.5")]
    public void ValidateGameVersion_ThrowsArgumentException_WhenGivenInvalidInput(string invalidInput)
    {
        var expected = "\nYou must enter an integer for the game version. Please try again.";
        
        var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateGameVersion(invalidInput));
        
        Assert.Equal(expected, ex.Message);
    }
    
    [Theory]
    [InlineData("-0")]
    [InlineData("0")]
    [InlineData("550")]
    public void ValidateGameVersion_ThrowsNoArgumentException_WhenGivenValidInput(string invalidInput)
    {
        Validator.ValidateGameVersion(invalidInput);
    }

    public static IEnumerable<object[]> GetGameVersionAndInvalidWorldDimensions()
    {
        yield return new object[] { 2, new List<string> {"5", "5", "5"} };
        yield return new object[] { 2, new List<string> {"5"} };
        yield return new object[] { 3, new List<string> {"5", "5", "5", "5"} };
        yield return new object[] { 3, new List<string> { "5", "5" } };
        yield return new object[] { 1, new List<string> {"5", "5", "5",} };
        yield return new object[] { 2, new List<string> {"5"} };
    }
    
    [Theory]
    [MemberData(nameof(GetGameVersionAndInvalidWorldDimensions))]
    public void ValidateWorldDimensions_ThrowsArgumentException_WhenGivenInvalidWorldDimensionsLength(int gameVersion,
        List<string> worldDimensions)
    {
        Assert.Throws<ArgumentException>(() => Validator.ValidateWorldDimensions(gameVersion, worldDimensions));
    }
    
    public static IEnumerable<object[]> GetGameVersionAndValidWorldDimensions()
    {
        yield return new object[] { 2, new List<string> {"5", "5"} };
        yield return new object[] { 3, new List<string> {"5", "5", "5"} };
        yield return new object[] { 1, new List<string> {"5", "5"} };
        yield return new object[] { 5, new List<string> {"5", "5"} };
    }
    
    [Theory]
    [MemberData(nameof(GetGameVersionAndValidWorldDimensions))]
    public void ValidateWorldDimensionsLength_ThrowsNoArgumentException_WhenGivenValidWorldDimensionsLength(int gameVersion,
        List<string> worldDimensions)
    {
        Validator.ValidateWorldDimensions(gameVersion, worldDimensions);
    }
    
    public static IEnumerable<object[]> GetGameVersionAndNonIntegerWorldDimensions()
    {
        yield return new object[] { 2, new List<string> {"5", "s"} };
        yield return new object[] { 3, new List<string> { "5", "5", "?" } };
        yield return new object[] { 1, new List<string> {"5", ""} };
    }
    
    [Theory]
    [MemberData(nameof(GetGameVersionAndNonIntegerWorldDimensions))]
    public void ValidateWorldDimensions_ThrowsArgumentException_WhenGivenNonIntegerWorldDimensions(int gameVersion,
        List<string> worldDimensions)
    {
        var expected = "\nDimension values must be of type int. Please try again.";
        
        var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateWorldDimensions(gameVersion, worldDimensions));
        
        Assert.Equal(expected, ex.Message);
    }
    
    public static IEnumerable<object[]> GetGameVersionAndIntegerWorldDimensions()
    {
        yield return new object[] { 2, new List<string> {"5", "5"} };
        yield return new object[] { 3, new List<string> { "5", "5", "5" } };
        yield return new object[] { 1, new List<string> {"5", "5"} };
    }
    
    [Theory]
    [MemberData(nameof(GetGameVersionAndIntegerWorldDimensions))]
    public void ValidateWorldDimensions_ThrowsNoArgumentException_WhenGivenIntegerWorldDimensions(int gameVersion,
        List<string> worldDimensions)
    {
        Validator.ValidateWorldDimensions(gameVersion, worldDimensions);
    }
}