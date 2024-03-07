using Xunit;

namespace UnitTestSampleXunit
{
    internal class CalculatorTests
    {
        
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Add(3, 5);

            // Assert
            Assert.Equal(8, result);
        }

       
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Subtract(8, 3);

            // Assert
            Assert.Equal(5, result);
        }
    }
}
