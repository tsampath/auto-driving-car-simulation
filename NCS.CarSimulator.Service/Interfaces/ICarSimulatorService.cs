using System;
namespace NCS.CarSimulator.Domain.Interfaces
{
    public interface ICarSimulatorService
    {
        string Simulate(int width, int height, int x, int y, char direction, string commands);
    }
}
