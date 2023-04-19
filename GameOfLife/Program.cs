// See https://aka.ms/new-console-template for more information

using GameOfLife;
using GameOfLife.IO;

Console.WriteLine("Hello, World!");
var consoleReader = new ConsoleReader();
var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
var threeDimensionalWorldDisplayBuilder = new ThreeDimensionalWorldDisplayBuilder();
var consoleWriter = new ConsoleWriter(threeDimensionalWorldDisplayBuilder);
var twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor();
var threeDimensionalWorld = new ThreeDimensionalWorld(25, 5, 25, new RNG());
var threeDimensionalWorldProcessor = new ThreeDimensionalWorldProcessor();
var game = new Game(consoleReader, consoleWriter, threeDimensionalWorld, threeDimensionalWorldProcessor);

game.Initialize();