

using ToyRobotSimulator.Core.Enums;

namespace ToyRobotSimulator.Core.Contracts;

public interface IRobotService
{
    void Move();
    void Left();
    void Right();
    string Report();
    void Place(int x, int y, Direction direction);

}
