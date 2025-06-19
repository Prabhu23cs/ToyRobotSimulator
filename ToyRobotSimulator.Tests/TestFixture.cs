using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.Core.Contracts;
using ToyRobotSimulator.Infrastructure.Repositories;
namespace ToyRobotSimulator.Tests
{
    public class TestFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public TestFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<IRobotService, RobotService>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
