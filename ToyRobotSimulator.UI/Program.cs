// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.UI;

Console.WriteLine("Hello, World!");
var services = new ServiceCollection()
    .AddToyRobotSimulator();
var serviceProvider = services.BuildServiceProvider();

var robotConsoleUI = serviceProvider.GetRequiredService<RobotConsoleUI>();
robotConsoleUI.Start();
