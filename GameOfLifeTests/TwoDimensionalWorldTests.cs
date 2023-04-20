// using GameOfLife;
// using GameOfLife.Enums;
// using GameOfLife.Interfaces;
// using Moq;
//
// namespace GameOfLifeTests;
//
// public class TwoDimensionalWorldTests
// {
//     private readonly TwoDimensionalWorld _twoDimensionalWorld;
//     private readonly int _rows = 5;
//     private readonly int _cols = 5;
//     private readonly Mock<IRandomNumberGenerator> _mockRNG;
//     
//     public TwoDimensionalWorldTests()
//     {
//         _mockRNG = new Mock<IRandomNumberGenerator>();
//         _twoDimensionalWorld = new TwoDimensionalWorld(_rows, _cols, _mockRNG.Object);
//     }
//
//     [Fact]
//     public void CheckTwoDimensionalWorldExists_AfterCreatingIt()
//     {
//         Assert.NotNull(_twoDimensionalWorld);
//     }
//
//     [Fact]
//     public void TwoDimensionalWorld_Initializes2DArray_WhenCalled()
//     {
//         var expected = 25;
//         
//         var actual = (Cell[,])_twoDimensionalWorld.GetArrayOfCells();
//         
//         Assert.Equal(expected, actual.Length);
//     }
//
//     [Fact]
//     public void CreateDeadWorld_AllArrayValuesShouldBeDead_WhenConstructorCalled()
//     {
//         var expectedRow = new Cell[] { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) };
//
//         var arrayOfCells = (Cell[,])_twoDimensionalWorld.GetArrayOfCells();
//         var actualRow = Enumerable.Range(0, arrayOfCells.GetLength(0))
//             .Select(x => arrayOfCells[0, x])
//             .ToArray();
//         
//         for (var i = 0; i < expectedRow.Length; i++)
//         {
//             Assert.Equal(expectedRow[i].GetCellStateAsString(), actualRow[i].GetCellStateAsString());
//         } // have to compare GetCellStateAsString output as comparing two objects directly does not work, because it compares their ref values
//     }
//
//     [Fact]
//     public void RandomizeWorld_AllArrayValuesShouldBeAMixtureOfDeadAndAlive_WhenCalled()
//     {
//         _mockRNG.SetupSequence(x => x.GetRandomNumber())
//             .Returns(0)
//             .Returns(1)
//             .Returns(0)
//             .Returns(1)
//             .Returns(1);
//         var expectedRow = new Cell[] { new(CellState.Dead), new(CellState.Alive), new(CellState.Dead), new(CellState.Alive), new(CellState.Alive) };
//
//         _twoDimensionalWorld.RandomizeWorld();
//         var arrayOfCells = (Cell[,])_twoDimensionalWorld.GetArrayOfCells();
//         var actualRow = Enumerable.Range(0, arrayOfCells.GetLength(0))
//             .Select(x => arrayOfCells[0, x])
//             .ToArray();
//         
//         for (var i = 0; i < expectedRow.Length; i++)
//         {
//             Assert.Equal(expectedRow[i].GetCellStateAsString(), actualRow[i].GetCellStateAsString());
//         }
//     }
//     
//     [Fact]
//     public void GetWorldDimensions_ReturnsCorrectDimensions_WhenCalled()
//     {
//         var expected = new List<int> {5, 5};
//         
//         var actual = _twoDimensionalWorld.GetWorldDimensions();
//         
//         Assert.Equal(expected, actual);
//     }
//     
//     [Fact]
//     public void UpdateArrayOfCells_Updates2DArray_WhenCalled()
//     {
//         var newTwoDimensionalWorld = new Cell[,]
//         {
//             { new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) },
//             { new (CellState.Alive), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead) },
//             { new (CellState.Dead), new (CellState.Alive), new (CellState.Dead), new (CellState.Alive), new (CellState.Dead) },
//             { new (CellState.Dead), new (CellState.Dead), new (CellState.Alive), new (CellState.Alive), new (CellState.Dead) },
//             { new (CellState.Dead), new (CellState.Alive), new (CellState.Dead), new (CellState.Dead), new (CellState.Alive) }
//         };
//         
//         _twoDimensionalWorld.UpdateArrayOfCells(newTwoDimensionalWorld);
//         var updatedArrayOfCells = (Cell[,])_twoDimensionalWorld.GetArrayOfCells();
//
//         for (var row = 0; row < _rows; row++)
//         {
//             for (var col = 0; col < _cols; col++)
//             {
//                 Assert.Equal(newTwoDimensionalWorld[row, col], updatedArrayOfCells[row, col]);
//             }
//         }
//     }
// }