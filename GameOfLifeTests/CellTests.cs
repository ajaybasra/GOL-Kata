using GameOfLife;
using GameOfLife.Enums;

namespace GameOfLifeTests;

public class CellTests
{
    private readonly Cell _deadCell;
    private readonly Cell _aliveCell;
    public CellTests()
    {
        _deadCell = new Cell(CellState.Dead);
        _aliveCell = new Cell(CellState.Alive);
    }
    
    [Fact]
    public void GetCellStateAsString_ShouldReturnCorrectString_WhenCellDead()
    {
        var expected = "Dead";

        var actual = _deadCell.GetCellStateAsString();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void GetCellStateAsString_ShouldReturnCorrectString_WhenCellAlive()
    {        
        var expected = "Alive";

        var actual = _aliveCell.GetCellStateAsString();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void SetCellState_ShouldUpdateCellStateToDead_WhenDeadStateIsPassed()
    {
        var expected = "Dead";

        _aliveCell.SetCellState(CellState.Dead);
        var actual = _aliveCell.GetCellStateAsString();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void SetCellState_ShouldUpdateCellStateToAlive_WhenAliveStateIsPassed()
    {
        var expected = "Alive";

        _deadCell.SetCellState(CellState.Alive);
        var actual = _deadCell.GetCellStateAsString();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetCellStateAsSymbol_ShouldReturnCorrectSymbol_WhenCellIsDead()
    {
        var expected = ".";

        var actual = _deadCell.GetCellStateAsSymbol();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void GetCellStateAsSymbol_ShouldReturnCorrectSymbol_WhenCellIsAlive()
    {
        var expected = "X";

        var actual = _aliveCell.GetCellStateAsSymbol();
        
        Assert.Equal(expected, actual);
    }
    

}