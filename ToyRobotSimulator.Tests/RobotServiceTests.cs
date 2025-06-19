
using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.Core.Contracts;
using ToyRobotSimulator.Core.Enums;

namespace ToyRobotSimulator.Tests
{
    public class RobotServiceTests : IClassFixture<TestFixture>
    {
        private readonly IRobotService _robotService;

        public RobotServiceTests(TestFixture testFixture)
        {
            _robotService = testFixture.ServiceProvider.GetRequiredService<IRobotService>();
        }

        [Fact]
        public void Place_WithValidPosition()
        {
            int x = 0;
            int y = 0;
            Direction direction = Direction.NORTH;
            _robotService.Place(x, y, direction);
            var report = _robotService.Report();
            Assert.Equal("0,0,NORTH", report);
        }

        [Fact]
        public void Move()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Move();
            var report = _robotService.Report();
            Assert.Equal("0,1,NORTH", report);
        }

        [Fact]
        public void Left()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Left();
            var report = _robotService.Report();
            Assert.Equal("0,0,WEST", report);
        }

        [Fact]
        public void Right()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Right();
            var report = _robotService.Report();
            Assert.Equal("0,0,EAST", report);
        }

        [Fact]
        public void Report_NotPlaced()
        {
            var report = _robotService.Report();
            Assert.Equal("Not placed on the table", report);
        }

        [Fact]
        public void Report_WithMultipleCommands()
        {
            _robotService.Place(1,2,Direction.EAST);
            _robotService.Move();
            _robotService.Move();
            _robotService.Left();
            _robotService.Move();
            var report = _robotService.Report();
            Assert.Equal("3,3,NORTH", report);
        }
    }
}
