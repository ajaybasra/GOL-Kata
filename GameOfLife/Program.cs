// See https://aka.ms/new-console-template for more information

using GameOfLife;
using GameOfLife.IO;

Console.WriteLine("Hello, World!");
var consoleReader = new ConsoleReader();
var consoleWriter = new ConsoleWriter();
var threeDimensionalWorld = new ThreeDimensionalWorld(25, 5, 25, new RNG());
var worldFactory = new WorldProcessorFactory();
var argumentParser = new ArgumentParser(new CommandLine());
var game = new Game(consoleReader, consoleWriter, worldFactory, argumentParser);

game.Initialize();