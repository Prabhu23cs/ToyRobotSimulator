using ToyRobotSimulator.Core.Enums;

namespace ToyRobotSimulator.Core.Entities;

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }
    public bool IsPlaced { get; set; }
}
