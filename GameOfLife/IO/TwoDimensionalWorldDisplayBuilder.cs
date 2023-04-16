using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class TwoDimensionalWorldDisplayBuilder : IWorldDisplayBuilder
{
    public string Build(IWorld world)
    {
        var stringBuilder = new StringBuilder();
        var rows = world.GetWorldDimensions()[0];
        var cols = world.GetWorldDimensions()[1];
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                stringBuilder.Append(world.GetArrayOfCells()[i,j].GetCellStateAsSymbol());
            }
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }
}