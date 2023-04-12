using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class WorldBuilder : IWorldBuilder
{
    public string Build(IWorld world)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < world.GetWorldDimensions()[0]; i++)
        {
            for (var j = 0; j < world.GetWorldDimensions()[1]; j++)
            {
                stringBuilder.Append(world.GetArrayOfCells()[i,j].GetCellStateAsSymbol());
            }
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }
}