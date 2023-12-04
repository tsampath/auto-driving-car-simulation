using NCS.CarSimulator.Domain.Interfaces;

namespace NCS.CarSimulator.Domain.Services
{
    public class InputValidatorService: IInputValidatorService
    {
        private const char FORWARD = 'F';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        private const char DEFAULT_DIRECTION = 'N';
        private const string VALID_DIRECTION = "NESW";
        public bool IsValidFieldDimensions(string[] dimensions, out int width, out int height)
        {
            width = height = 0;

            if (dimensions.Length != 2 || !int.TryParse(dimensions[0], out width) || !int.TryParse(dimensions[1], out height))
            {
                return false;
            }

            return true;
        }

        public bool IsValidInitialPosition(string[] initialPosition, out int x, out int y, out char direction, int width, int height)
        {
            x = y = 0;
            direction = DEFAULT_DIRECTION;

            if (initialPosition.Length != 3 || !int.TryParse(initialPosition[0], out x) || !int.TryParse(initialPosition[1], out y) || !IsValidDirection(initialPosition[2]))
            {
                return false;
            }

            direction = char.Parse(initialPosition[2]);
            //Check for given condinates within the field or not 
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public bool IsValidCommands(string commands)
        {
            if(commands.Equals(string.Empty)) return false;
            foreach (char command in commands)
            {
                if (command != FORWARD && command != LEFT && command != RIGHT)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidDirection(string direction)
        {
            return direction.Length == 1 && VALID_DIRECTION.Contains(direction.ToUpper());
        }
    }
}
