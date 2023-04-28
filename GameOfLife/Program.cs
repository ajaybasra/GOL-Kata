// See https://aka.ms/new-console-template for more information

using GameOfLife;
using GameOfLife.IO;

var consoleWriter = new ConsoleWriter();
var worldFactory = new WorldProcessorFactory();
var argumentParser = new ArgumentParser(new CommandLine());
var game = new Game(consoleWriter, worldFactory, argumentParser);

game.Initialize();