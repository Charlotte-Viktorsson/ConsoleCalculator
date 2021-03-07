using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class ProgramTests
    {
        
        [Fact]
        public void MultiplyNormal()
        {
            //Arrange
            double d1 = 1.0;
            double d2 = 2.0;

            //Act
            double product = Program.Multiply(d1, d2);


            //Assert
            Assert.Equal(d1 * d2, product);
        }

        [Fact]
        public void MultiplyWithMinus()
        {
            //Arrange
            double d1 = -1.0;
            double d2 = 2.0;

            //Act
            double product = Program.Multiply(d1, d2);


            //Assert
            Assert.Equal(d1 * d2, product);
        }

        [Fact]
        public void AddNormal()
        {
            //Arrange
            double d1 = 1.5;
            double d2 = 3.0;

            //Act
            double sum = Program.Addition(d1, d2);

            //Assert
            Assert.Equal(d1 + d2, sum);
        }

        [Fact]
        public void AddWithMinus()
        {
            //Arrange
            double d1 = -1.5;
            double d2 = 3.0;

            //Act
            double sum = Program.Addition(d1, d2);

            //Assert
            Assert.Equal(d1 + d2, sum);
        }

        [Fact]
        public void SubtractNormal()
        {
            //Arrange
            double d1 = 1000;
            double d2 = 1000;
            //Act
            double difference = Program.Subtraction(d1, d2);
            //Assert
            Assert.Equal(d1-d2, difference);
        }

        [Fact]
        public void SubtractWithMinus()
        {
            //Arrange
            double d1 = 1000;
            double d2 = -1000;
            //Act
            double difference = Program.Subtraction(d1, d2);
            //Assert
            Assert.Equal(d1 - d2, difference);
        }

        [Fact]
        public void DivideNormal()
        {
            //Arrange
            double d1 = 1000;
            double d2 = 1000;
            //Act
            double quota = Program.Division(d1, d2);
            //Assert
            Assert.Equal(d1 / d2, quota);
        }

        [Fact]
        public void DivideWithZero()
        {
            //Arrange
            double d1 = 1000;
            double d2 = 0;
            //Act
            //0 should be returned if denominator is 0
            double quota = Program.Division(d1, d2);
            
            //Assert
            //here I would like to assert the console.WriteLine to the user too.
            Assert.Equal(0, quota);
        }

        [Fact]
        public void DivideWithMinus()
        {
            //Arrange
            double d1 = double.MaxValue;
            double d2 = double.MinValue;

            //Act
            //0 should be returned if denominator is 0
            double quota = Program.Division(d1, d2);
            
            //Assert
            Assert.Equal(d1 / d2, quota);
        }

        [Theory]
        [InlineData(new double[] { 3.5, 4.5, 1.0 }, "Sum is 9")]
        [InlineData(new double[] { 3.5, 4.5}, "Sum is 8")]
        [InlineData(new double[] { 0.5, -1 }, "Sum is -0,5")]
        [InlineData(new double[] { -1 }, "Sum is -1")]
        [InlineData(new double[] { }, "No number entered")]
        public void AddSeveralNumbers(double[] doubleArray, string expectedResult)
        {
            //Arrange
            
            //Act
            string result = Program.Addition(doubleArray);

            //Assert
            Assert.Contains(expectedResult, result);
        }

        [Theory]
        [InlineData(new double[] { 100, 10, 1.0 }, "Difference is 89")]
        [InlineData(new double[] { 10, -5 }, "Difference is 15")]
        [InlineData(new double[] { 0.5, -1 }, "Difference is 1,5")] //-- => +
        [InlineData(new double[] { 89, 0 }, "Difference is 89")]
        [InlineData(new double[] { double.MaxValue, double.MaxValue }, "Difference is 0")]
        [InlineData(new double[] { -1 }, "Only one number entered: -1")]
        [InlineData(new double[] { }, "No number entered")]
        public void SubtractSeveralNumbers(double[] doubleArray, string expectedResult)
        {
            //Arrange

            //Act
            string result = Program.Subtraction(doubleArray);

            //Assert
            Assert.Contains(expectedResult, result);
        }

    }
}
