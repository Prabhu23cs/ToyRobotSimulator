
using ToyRobotSimulator.Core.Contracts;
using ToyRobotSimulator.Core.Enums;

namespace ToyRobotSimulator.Infrastructure.Repositories;

public class RobotService : IRobotService
{
    private const int TABLE_WIDTH = 5;
    private const int TABLE_HEIGHT = 5;
    private int _x;
    private int _y;
    private Direction _direction;
    private bool _isPlaced = false;
    public void Left()
    {
        if (!_isPlaced)
        {
            return;
        }
        _direction = (Direction)(((int)_direction + 3) % 4);
    }

    public void Move()
    {
        if(!_isPlaced)
        {
            return;
        }

        int newX = _x;
        int newY = _y;

        switch(_direction)
        {
            case Direction.NORTH:
                newY++;
                break;
            case Direction.EAST:
                newX++;
                break;
            case Direction.SOUTH:
                newY--;
                break;
            case Direction.WEST:
                newX--;
                break;
        }

        if(IsValidPosition(newX, newY))
        {
            _x = newX;
            _y = newY;
        }
    }

    public void Place(int x, int y, Direction direction)
    {
        if (IsValidPosition(x, y))
        {
            _x = x;
            _y = y;
            _direction = direction;
            _isPlaced = true;
        }
    }

    public string Report()
    {
        return _isPlaced ? "" + _x + "," + _y + "," + _direction : "Not placed on the table";
    }

    public void Right()
    {
        if (!_isPlaced)
        {
            return;
        }
        _direction = (Direction)(((int)_direction + 1) % 4);
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < TABLE_WIDTH && y >= 0 && y < TABLE_HEIGHT;
    }
}
