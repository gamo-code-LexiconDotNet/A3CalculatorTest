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
            // test numbers length
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
            // test numbers length
            double sum = numbers[0] * 2;
            foreach (double number in numbers)
                sum -= number;
            return sum;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
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

        // b root of a
        public double Root(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return Math.Pow(a, 1 / b);
        }


        // log a base b
        public double Log(double a, double b)
        {
            return Math.Log(a) / Math.Log(b);
        }
    }
}
