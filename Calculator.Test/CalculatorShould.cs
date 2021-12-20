using System;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorShould
    {
        private readonly Calculator _sut;

        public CalculatorShould()
        {
            _sut = new Calculator();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(123, -23, 100)]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(-1.23, 2.27, 1.04)]
        [InlineData(1.23, -0.23, 1.00)]
        public void AddTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Add(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 1, -2)]
        [InlineData(123, -23, 146)]
        [InlineData(0.1, 0.2, -0.1)]
        [InlineData(-1.23, 2.27, -3.5)]
        [InlineData(1.23, -0.23, 1.46)]
        public void SubractTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Subtract(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(123, -23, -5.34782)]
        [InlineData(0.1, 0.2, 0.5)]
        [InlineData(-1.23, 2.27, -0.54185)]
        [InlineData(1.23, -0.23, -5.34782)]
        public void DivideTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Divide(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(123, -23, -2829)]
        [InlineData(0.1, 0.2, 0.02)]
        [InlineData(-1.23, 2.27, -2.7921)]
        [InlineData(1.23, -0.23, -0.2829)]
        public void MultiplyTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Multiply(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 1, 0)]
        [InlineData(123, -23, 8)]
        [InlineData(0.1, 0.2, 0.1)]
        [InlineData(-1.23, 2.27, -1.23)]
        [InlineData(1.23, -0.23, 0.08)]
        public void ModuloOfTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Modulo(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(123, 2, 15129)]
        [InlineData(0.1, 0.2, 0.63095)]
        [InlineData(1.23, 2.27, 1.59986)]
        [InlineData(1.23, -0.23, 0.95350)]
        public void PowerOfTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Power(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(123, 2, 11.0905365)]
        [InlineData(0.1, 0.2, 0.00001)]
        [InlineData(1.23, 2.27, 1.09548)]
        [InlineData(1.23, -0.23, 0.4065)]
        public void RootOfTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Root(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(16, 4, 2)]
        [InlineData(4, 16, 0.5)]
        [InlineData(100, 10, 2)]
        [InlineData(0.1, 0.2, 1.43067)]
        [InlineData(1.23, 2.27, 0.25252)]
        [InlineData(1.23, 0.23, -0.1408570)]
        public void LogBaseTwoNumbers(double a, double b, double expected)
        {
            // assemble
            double result;

            // act
            result = _sut.Log(a, b);

            // assert
            Assert.Equal(expected, result, 4);
        }


        [Fact]
        public void ThrowWhenDividingByZero()
        {
            // assemble
            double a = 1;
            double b = 0;

            // act

            // assert
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(a, b));
            Assert.Throws<DivideByZeroException>(() => _sut.Root(a, b));
        }
    }
}
