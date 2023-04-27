using GameOfLife;
using GameOfLife.Interfaces;
using GameOfLife.IO;
using Moq;
using NSubstitute;

namespace GameOfLifeTests;

public class GameTests
{
    private  readonly string[] _args = { "pathname", "2", "5", "5" };
    private readonly Mock<ICommandLine> _mockCommandLine;
    private readonly Mock<IWriter> _mockedConsoleWriter;
    private readonly Mock<IRandomNumberGenerator> _mockRNG;
    private readonly  TwoDimensionalWorld _twoDimensionalWorld;
    private readonly TwoDimensionalWorldProcessor _twoDimensionalWorldProcessor;
    private readonly Mock<IWorldProcessorFactory> _mockWorldProcessorFactory;
    public GameTests()
    {
        _mockCommandLine = new Mock<ICommandLine>();
        _mockCommandLine.Setup(x => x.GetCommandLineArgs()).Returns(_args);
        _mockedConsoleWriter = new Mock<IWriter>();
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _mockRNG.Setup(x => x.GetRandomNumber()).Returns(0);
        _twoDimensionalWorld = new TwoDimensionalWorld(5, 5, _mockRNG.Object);
        _twoDimensionalWorld.RandomizeWorld();
        _twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(_twoDimensionalWorld,
            new TwoDimensionalWorldDisplayBuilder(), new TwoDimensionalWorldNeighbourProcessor());
        _mockWorldProcessorFactory = new Mock<IWorldProcessorFactory>();
        _mockWorldProcessorFactory.Setup(x => x.CreateTwoDimensionalWorldProcessor(It.IsAny<List<int>>()))
            .Returns(_twoDimensionalWorldProcessor);
    }
    
    [Fact]
    public void Initialize_ShouldPrintIntroAndStartNewGame()
    {
        var game = new Game(new ConsoleReader(), _mockedConsoleWriter.Object, _mockWorldProcessorFactory.Object,
            new ArgumentParser(_mockCommandLine.Object));
        
        game.Initialize();
        
        _mockedConsoleWriter.Verify(console => console.WriteLine(GameMessageBuilder.IntroMessage()), Times.Exactly(1));
    }

    [Fact]
    public void Initialize_ShouldPrintOutro_WhenGameFinished()
    {
        var game = new Game(new ConsoleReader(), _mockedConsoleWriter.Object, _mockWorldProcessorFactory.Object,
             new ArgumentParser(_mockCommandLine.Object));
         
         game.Initialize();
         
         _mockedConsoleWriter.Verify(console => console.WriteLine(GameMessageBuilder.OutroMessage()), Times.Exactly(1));
    }

    [Fact]
    public void GivenAPredeterminedBoard_GamePerformsThreeIterationsBeforeWorldStabilisesAndReturnsCorrectBoardVisualizations()
    {
        const string firstExpectedGameDisplay = ".X..X\n.XX..\nXXXX.\n.X.XX\nX.XXX\n";
        const string secondExpectedGameDisplay = "....X\n....X\n.....\n.....\n.....\n";
        const string thirdExpectedGameDisplay = ".....\n.....\n.....\n.....\n.....\n";
        _mockRNG.SetupSequence(x => x.GetRandomNumber()) 
            .Returns(0) 
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(0)
            .Returns(0)
            .Returns(1)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(1)
            .Returns(0)
            .Returns(1)
            .Returns(1)
            .Returns(1);
        var game = new Game(new ConsoleReader(), _mockedConsoleWriter.Object, _mockWorldProcessorFactory.Object,
            new ArgumentParser(_mockCommandLine.Object));
        
        _twoDimensionalWorld.RandomizeWorld();
        game.Initialize();

        _mockedConsoleWriter.Verify(console => console.WriteLine(firstExpectedGameDisplay), Times.Exactly(1));
        _mockedConsoleWriter.Verify(console => console.WriteLine(secondExpectedGameDisplay), Times.Exactly(1));
        _mockedConsoleWriter.Verify(console => console.WriteLine(thirdExpectedGameDisplay), Times.Exactly(1));
    } 
}

