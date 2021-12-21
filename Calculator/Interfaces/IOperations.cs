using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IOperations
    {
        public double Add(double a, double b);
        public double Add(double[] numbers);
        public double Subtract(double a, double b);
        public double Subtract(double[] numbers);
        public double Divide(double a, double b);
        public double Multiply(double a, double b);
        public double Modulo(double a, double b);
        public double Power(double a, double b);
        public double Root(double a, double b);
        public double Log(double a, double b);
    }
}
