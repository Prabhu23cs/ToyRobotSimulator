using ToyRobotSimulator.Core.Contracts;

namespace ToyRobotSimulator.UI;

public class RobotConsoleUI
{
    private readonly ICommandProcessor _commandProcessor;

    public RobotConsoleUI(ICommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Toy Robot Simulator!");
        Console.WriteLine("Available commands: PLACE(x,y,direction), MOVE, LEFT, RIGHT, REPORT, EXIT");
        Console.WriteLine("Direction can be NORTH, EAST, SOUTH, or WEST.");

        while (true)
        {
            Console.Write("Enter command: ");
            var input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            if (input.Trim().ToUpper() == "EXIT")
            {
                break;
            }
            _commandProcessor.ProcessCommand(input);
        }
    }
}
