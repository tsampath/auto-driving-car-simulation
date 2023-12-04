using NCS.CarSimulator.Domain.Interfaces;

namespace NCS.CarSimulator.Console
{
    public class Application
    {
        private readonly ICarSimulatorService CarSimulatorService;
        private readonly IInputValidatorService InputValidatorService;

        private const string OPTION_ONE = "1";
        private const string OPTION_TWO = "2";
        public Application(ICarSimulatorService carSimulatorService, IInputValidatorService inputValidatorService)
        {
            this.CarSimulatorService = carSimulatorService;
            this.InputValidatorService = inputValidatorService;
        }
        public void Run()
        {
            while (true)
            {
                System.Console.WriteLine("Menu:");
                System.Console.WriteLine("1. Run Car Simulator");
                System.Console.WriteLine("2. Exit");

                System.Console.Write("Enter your choice: ");
                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case OPTION_ONE:
                        RunCarSimulator();
                        break;
                    case OPTION_TWO:
                        System.Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }
            }
        }

        private void RunCarSimulator()
        {
            int width, height, x, y;
            char direction;
            string commands;

            // Field Dimensions
            do
            {
                System.Console.WriteLine("Enter the field dimensions (width height):");
                string[] fieldDimensions = System.Console.ReadLine().Split(' ');

                if (!this.InputValidatorService.IsValidFieldDimensions(fieldDimensions, out width, out height))
                {
                    System.Console.WriteLine("Invalid field dimensions. Please try again.");
                        
                }
                else
                {
                    break; // Break the loop if input is valid
                }

            } while (true);


            // Initial Position
            do
            {
                System.Console.WriteLine("Enter the initial position and direction of the car (x y direction):");
                string[] initialPosition = System.Console.ReadLine().Split(' ');

                if (!this.InputValidatorService.IsValidInitialPosition(initialPosition, out x, out y, out direction, width, height))
                {
                    System.Console.WriteLine("Invalid initial position or direction. Please try again.");               
                }
                else
                {
                    direction = char.Parse(initialPosition[2]);
                    break; // Break the loop if input is valid
                }
            } while (true);

            // Commands
            do
            {
                System.Console.WriteLine("Enter the commands:");
                commands = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(commands) || !this.InputValidatorService.IsValidCommands(commands))
                {
                    System.Console.WriteLine("Invalid commands. Please try again.");
                }
                else
                {
                    break; // Break the loop if input is valid
                }

            } while (true);

            System.Console.WriteLine(this.CarSimulatorService.Simulate(width, height, x, y, direction, commands));
        }
    }
}
