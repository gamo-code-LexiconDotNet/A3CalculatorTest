using System;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
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
