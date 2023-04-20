// See https://aka.ms/new-console-template for more information

using GameOfLife;
using GameOfLife.IO;

Console.WriteLine("Hello, World!");
var consoleReader = new ConsoleReader();
var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
var threeDimensionalWorldDisplayBuilder = new ThreeDimensionalWorldDisplayBuilder();
var consoleWriter = new ConsoleWriter();
var twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor(twoDimensionalWorld, twoDimensionalWorldDisplayBuilder);
var threeDimensionalWorld = new ThreeDimensionalWorld(25, 5, 25, new RNG());
var threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor(threeDimensionalWorld, threeDimensionalWorldDisplayBuilder);
var game = new Game(consoleReader, consoleWriter, twoDimensionalWorld, twoDimensionalWorldProcessor);

game.Initialize();