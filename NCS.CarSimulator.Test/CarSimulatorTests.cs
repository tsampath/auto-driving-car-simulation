using NCS.CarSimulator.Domain.Interfaces;
using NCS.CarSimulator.Domain.Services;

namespace NCS.CarSimulator.Test
{
    [TestFixture]
    public class CarSimulatorTests
    {
        private ICarSimulatorService CarSimulatorService;

        [SetUp]
        public void Init()
        {
            this.CarSimulatorService = new CarSimulatorService();
        }

        [Test] 
        public void Simulate_CarMovesForward_10_10_N_Success()
        {

            // Arrange
            int width = 10, height = 10, x = 1, y = 2;
            char direction = 'N';
            string commands = "FFRFFFRRLF";

            // Act
            var finalPosition = this.CarSimulatorService.Simulate(width, height, x, y, direction, commands);

            // Assert
            Assert.That(finalPosition, Is.EqualTo("4 3 S"));
        }

        [Test]
        public void Simulate_CarMovesForwardOutSide_X_Right_2_10_N_Success()
        {

            // Arrange
            int width = 2, height = 10, x = 1, y = 2;
            char direction = 'N';
            string commands = "FFRFFFRRLF";

            // Act
            var finalPosition = this.CarSimulatorService.Simulate(width, height, x, y, direction, commands);

            // Assert
            Assert.That(finalPosition, Is.EqualTo("1 3 S"));
        }

        [Test]
        public void Simulate_CarMovesForwardOutSide_X_Right_10_10_N_Success()
        {

            // Arrange
            int width = 10, height = 10, x = 9, y = 5;
            char direction = 'N';
            string commands = "FFRFFFRRLF";

            // Act
            var finalPosition = this.CarSimulatorService.Simulate(width, height, x, y, direction, commands);

            // Assert
            Assert.That(finalPosition, Is.EqualTo("9 6 S"));
        }

        [Test]
        public void Simulate_CarMovesForwardOutSide_Y_6_2_S_Success()
        {

            // Arrange
            int width = 6, height = 2, x = 1, y = 1;
            char direction = 'S';
            string commands = "FFRFFFRRLF";

            // Act
            var finalPosition = this.CarSimulatorService.Simulate(width, height, x, y, direction, commands);

            // Assert
            Assert.That(finalPosition, Is.EqualTo("0 1 N"));
        }

        [Test]
        public void Simulate_CarMovesForwardOutside_Y_10_10_N_Success()
        {
            // Arrange
            int width = 10, height = 10, x = 1, y = 2;
            char direction = 'N';
            string commands = "RFRFFFFLFLFF";

            // Act
            var finalPosition = this.CarSimulatorService.Simulate(width, height, x, y, direction, commands);

            // Assert
            Assert.That(finalPosition, Is.EqualTo("3 2 N"));
        }
    }

}
