namespace GameOfLife.Interfaces;

public interface IWriter
{
    void Write(string output);
    void WriteLine(string output);

    void Clear();
    // string BuildWorld(IWorld world);

}