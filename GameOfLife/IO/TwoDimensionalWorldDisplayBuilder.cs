using System.Data;
using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class TwoDimensionalWorldDisplayBuilder
{
    public string Build(TwoDimensionalWorld world, int rows, int cols)
    {
        var stringBuilder = new StringBuilder();
        
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