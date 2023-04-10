using GameOfLife.Enums;

namespace GameOfLife;

public class Cell
{
    private CellState _cellState;

    public Cell(CellState cellState)
    {
        _cellState = cellState;
    }

    public string GetCellStateAsString()
    {
        throw new NotImplementedException();
    }

    public void SetCellState(CellState cellState)
    {
        _cellState = cellState;
    }
}