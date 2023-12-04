namespace NCS.CarSimulator.Domain.Interfaces
{
    public interface IInputValidatorService
    {
        bool IsValidFieldDimensions(string[] dimensions, out int width, out int height);

        bool IsValidInitialPosition(string[] initialPosition, out int x, out int y, out char direction, int width, int height);

        bool IsValidCommands(string commands);

        bool IsValidDirection(string direction);
    }
}
