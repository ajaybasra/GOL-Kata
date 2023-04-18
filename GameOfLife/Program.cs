// See https://aka.ms/new-console-template for more information

using GameOfLife;
using GameOfLife.IO;

Console.WriteLine("Hello, World!");
var consoleReader = new ConsoleReader();
var twoDimensionalWorldDisplayBuilder = new TwoDimensionalWorldDisplayBuilder();
var consoleWriter = new ConsoleWriter(twoDimensionalWorldDisplayBuilder);
var twoDimensionalWorld = new TwoDimensionalWorld(5, 5, new RNG());
var twoDimensionalWorldProcessor = new TwoDimensionalWorldProcessor();
var game = new Game(consoleReader, consoleWriter, twoDimensionalWorld, twoDimensionalWorldProcessor);

game.Initialize();