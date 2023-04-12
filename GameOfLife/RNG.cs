using GameOfLife.Interfaces;

namespace GameOfLife;

public class RNG : IRandomNumberGenerator
{
    public int GetRandomNumber()
    {
        var rnd = new Random();
        return rnd.Next(0, 2);
    }
}