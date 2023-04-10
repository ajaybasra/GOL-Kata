namespace GameOfLife.IO;

public static class GameMessageBuilder
{
    public static string IntroMessage()
    {
        return "Welcome to Conway's Game of Life! Press any key to continue.\n";
    }
    
    public static string OutroMessage()
    {
        return "Thank you for playing the Game of Life, hope you had fun!";
    }
}