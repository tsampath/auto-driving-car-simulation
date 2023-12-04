using NCS.CarSimulator.Domain.Interfaces;
using NCS.CarSimulator.Domain.Services;

namespace NCS.CarSimulator.Test
{
    [TestFixture]
    public class InputValidatorTests
    {
        private IInputValidatorService InputValidatorService;

        [SetUp]
        public void Init()
        {
            this.InputValidatorService = new InputValidatorService();
        }

        [TestCase("invalid", false, 0, 0, 'N', 10, 10)]
        [TestCase("10 4 N", false, 10, 4, 'N', 2, 5)]
        [TestCase("1 2 S", false, 1, 2, 'S', 6, 2)]
        [TestCase("1 2 N", true, 1, 2, 'N', 10, 10)]
        [TestCase("1 2 N", true, 1, 2, 'N', 2, 10)]
        [TestCase("9 5 N", true, 9, 5, 'N', 10, 10)]
        [TestCase("1 1 S", true, 1, 1, 'S', 6, 2)]
        [TestCase("1 2 N", true, 1, 2, 'N', 10, 10)]
        public void IsValidInitialPosition_ValidInput_ReturnsExpectedResult(string input, bool expectedResult, int expectedX, int expectedY, char expectedDirection,
                                                                            int width, int height)
        {
            // Arrange & Act
            bool result = this.InputValidatorService.IsValidInitialPosition(input.Split(' '), out int x, out int y, out char direction, width, height);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(x, Is.EqualTo(expectedX));
            Assert.That(y, Is.EqualTo(expectedY));
            Assert.That(direction, Is.EqualTo(expectedDirection));

        }

        [TestCase("FLLLRRLR", true)]
        [TestCase("", false)]
        [TestCase("123456", false)]
        [TestCase("FLLLKRRLR", false)]
        public void IsValidCommands_ValidInput_ReturnsExpectedResult(string input, bool expectedResult)
        {
            // Arrange & Act
            bool result = this.InputValidatorService.IsValidCommands(input);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("N", true)]
        [TestCase("E", true)]
        [TestCase("S", true)]
        [TestCase("W", true)]
        [TestCase("T", false)]
        public void IsValidDirection_ValidInput_ReturnsExpectedResult(string input, bool expectedResult)
        {
            // Arrange & Act
            bool result = this.InputValidatorService.IsValidDirection(input);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

}
