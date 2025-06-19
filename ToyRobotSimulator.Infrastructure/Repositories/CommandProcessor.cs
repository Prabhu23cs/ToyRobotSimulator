
using ToyRobotSimulator.Core.Contracts;
using ToyRobotSimulator.Core.Enums;

namespace ToyRobotSimulator.Infrastructure.Repositories;

public class CommandProcessor : ICommandProcessor
{
    private readonly IRobotService _robotService;

    public CommandProcessor(IRobotService robotService)
    {
        _robotService = robotService;
    }
    public void ProcessCommand(string command)
    {
        if (string.IsNullOrWhiteSpace(command))
        {
            return;
        }

        command = command.Trim().ToUpper();

        if (command.StartsWith("PLACE"))
        {
            HandlePlace(command);
            return;
        }

        if (Enum.TryParse<ActionCommand>(command, true, out var parsedCommand))
        {
            switch (parsedCommand)
            {
                case ActionCommand.MOVE:
                    _robotService.Move();
                    break;
                case ActionCommand.LEFT:
                    _robotService.Left();
                    break;
                case ActionCommand.RIGHT:
                    _robotService.Right();
                    break;
                case ActionCommand.REPORT:
                    Console.WriteLine(_robotService.Report());
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid command.");
        }
    }
    private void HandlePlace(string command)
    {
        var startIndex = command.IndexOf("(");
        var endIndex = command.IndexOf(")");

        if (startIndex < 0 || endIndex < 0 || endIndex <= startIndex + 1)
        {
            return;
        }

        var directionPart = command.Substring(startIndex + 1, endIndex - startIndex - 1);
        var args = directionPart.Split(',')
            .Select(x => x.Trim())
            .ToArray();
        if (args.Length == 3 &&
            int.TryParse(args[0], out int x) &&
            int.TryParse(args[1], out int y) &&
            Enum.TryParse(args[2], true, out Direction direction))
        {
            _robotService.Place(x, y, direction);
        }
        else
        {
            Console.WriteLine("Invalid command.");
            return; 
        }
    }
}
