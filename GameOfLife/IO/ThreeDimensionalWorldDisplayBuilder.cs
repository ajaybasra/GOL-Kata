using System.Text;
using GameOfLife.Interfaces;

namespace GameOfLife.IO;

public class ThreeDimensionalWorldDisplayBuilder
{
    public string Build(ThreeDimensionalWorld world)
    {
        var stringBuilder = new StringBuilder();
        var aisles = world.GetWorldDimensions()[0];
        var rows = world.GetWorldDimensions()[1];
        var cols = world.GetWorldDimensions()[2];
        
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