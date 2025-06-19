using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.Core.Contracts;
using ToyRobotSimulator.Infrastructure.Repositories;

namespace ToyRobotSimulator.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddToyRobotSimulator(this IServiceCollection services)
    {
        services.AddScoped<IRobotService, RobotService>();
        services.AddScoped<ICommandProcessor, CommandProcessor>();

        services.AddSingleton<RobotConsoleUI>();
        return services;
    }
}
