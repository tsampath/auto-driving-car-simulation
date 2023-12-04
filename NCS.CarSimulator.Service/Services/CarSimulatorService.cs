using NCS.CarSimulator.Domain.Interfaces;

namespace NCS.CarSimulator.Domain.Services
{
    public class CarSimulatorService: ICarSimulatorService
    {
        private const char FORWARD = 'F';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        private const char NORTH = 'N';
        private const char EAST = 'E';
        private const char SOUTH = 'S';
        private const char WEST = 'W';

        public string Simulate(int width, int height, int x, int y, char direction, string commands)
        {
            foreach (char command in commands)
            {
                switch (command)
                {
                    case FORWARD:
                        MoveForward(ref x, ref y, direction, width, height);
                        break;
                    case LEFT:
                        TurnLeft(ref direction);
                        break;
                    case RIGHT:
                        TurnRight(ref direction);
                        break;
                    default:
                        Console.WriteLine($"Invalid command '{command}'. Ignoring.");
                        break;
                }
            }

            return ($"{x} {y} {direction}");
        }

        private void MoveForward(ref int x, ref int y, char direction, int width, int height)
        {
            switch (direction)
            {
                case NORTH:
                    if (y + 1 < height) y++;
                    break;
                case EAST:
                    if (x + 1 < width) x++;
                    break;
                case SOUTH:
                    if (y - 1 >= 0) y--;
                    break;
                case WEST:
                    if (x - 1 >= 0) x--;
                    break;
            }
        }

        private void TurnLeft(ref char direction)
        {
            switch (direction)
            {
                case NORTH: direction = WEST; break;
                case EAST: direction = NORTH; break;
                case SOUTH: direction = EAST; break;
                case WEST: direction = SOUTH; break;
            }
        }

        private void TurnRight(ref char direction)
        {
            switch (direction)
            {
                case NORTH: direction = EAST; break;
                case EAST: direction = SOUTH; break;
                case SOUTH: direction = WEST; break;
                case WEST: direction = NORTH; break;
            }
        }
    }
}