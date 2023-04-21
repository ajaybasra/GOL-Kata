using System.Data;
using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class TwoDimensionalWorldDisplayBuilder
{
    public string Build(TwoDimensionalWorld world)
    {
        var stringBuilder = new StringBuilder();
        var rows = world.GetWorldDimensions()[0];
        var cols = world.GetWorldDimensions()[1];
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                var twoDimensionalWorldArray = world.ArrayOfCells;
                stringBuilder.Append(twoDimensionalWorldArray[i,j].GetCellStateAsSymbol());
            }
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }
}