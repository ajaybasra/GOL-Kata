using GameOfLife.Enums;
using GameOfLife.Constants;
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

    public bool IsCellAlive()
    {
        return _cellState is CellState.Alive;
    }
}