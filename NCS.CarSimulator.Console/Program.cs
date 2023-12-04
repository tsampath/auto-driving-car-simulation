using Microsoft.Extensions.DependencyInjection;

using NCS.CarSimulator.Console;
using NCS.CarSimulator.Domain.Interfaces;
using NCS.CarSimulator.Domain.Services;

// Create the service container
var builder = new ServiceCollection()
        .AddSingleton<Application, Application>()
        .AddSingleton<ICarSimulatorService, CarSimulatorService>()
        .AddSingleton<IInputValidatorService, InputValidatorService>()
        .BuildServiceProvider();
    Application app = builder.GetRequiredService<Application>();
app.Run();


