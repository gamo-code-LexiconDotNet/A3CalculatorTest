using System;

namespace Calculator
{
    public class Operations : IOperations
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Add(double[] numbers)
        {
            if (numbers.Length < 2)
                throw new ArgumentException("Must input at least 2 numbers");
            double sum = 0;
            foreach (double number in numbers)
                sum += number;
            return sum;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Subtract(double[] numbers)
        {
            if (numbers.Length < 2)
                throw new ArgumentException("Must input at least 2 numbers");
            double sum = numbers[0] * 2;
            foreach (double number in numbers)
                sum -= number;
            return sum;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Modulo(double a, double b)
        {
            return a % b;
        }

        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public double Root(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return Math.Round(Math.Pow(a, 1.0 / b), 15);
        }

        public double Log(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Cannot Log negative numbers.");
            return Math.Log(a) / Math.Log(b);
        }
    }
}
