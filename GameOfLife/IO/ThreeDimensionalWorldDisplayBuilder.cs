using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class ThreeDimensionalWorldDisplayBuilder
{
    public string Build(ThreeDimensionalWorld world, int aisles, int rows, int cols)
    {
        var stringBuilder = new StringBuilder();
        
        for (var i = 0; i < aisles ; i++)
        {
            stringBuilder.AppendLine($"Dimension number {i + 1}:");
            
            for (var j = 0; j < rows; j++)
            {
                for (var k = 0; k < cols; k++)
                {
                    var threeDimensionalWorldArray = world.ArrayOfCells;
                    stringBuilder.Append(threeDimensionalWorldArray[i, j, k].GetCellStateAsSymbol());
                }
                stringBuilder.Append('\n');
            }
            stringBuilder.Append(GetLineSeparator(cols));
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }
    
    private string GetLineSeparator(int numberOfCols)
    {
        var lineSeparator = "";

        for (var i = 0; i < numberOfCols; i++)
        {
            lineSeparator += "_";
        }

        return lineSeparator;
    }
}