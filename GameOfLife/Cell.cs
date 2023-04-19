using GameOfLife.Enums;

namespace GameOfLife;

public class Cell
{
    private CellState _cellState;

    public Cell(CellState cellState)
    {
        _cellState = cellState;
    }

    public static object Alive { get; set; }

    public string GetCellStateAsString()
    {
        return _cellState.ToString();
    }

    public CellState GetCellState()
    {
        return _cellState;
    }
    public void SetCellState(CellState cellState)
    {
        _cellState = cellState;
    }

    public string GetCellStateAsSymbol()
    {
        return _cellState is CellState.Dead ? Constants.Constants.Dead : Constants.Constants.Alive;
    }

    public bool isCellAlive()
    {
        return _cellState is CellState.Alive;
    }
}