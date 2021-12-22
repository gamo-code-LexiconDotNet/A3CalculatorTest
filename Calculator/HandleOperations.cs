using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class HandleOperations : IHandleOperations
    {
        private readonly IHandleInput inputHandler;
        private readonly IOperations operations;
        private readonly IConsoleWrapper consoleWrapper;

        public HandleOperations(
            IHandleInput inputHandler,
            IOperations operations,
            IConsoleWrapper consoleWrapper)
        {
            this.inputHandler = inputHandler;
            this.operations = operations;
            this.consoleWrapper = consoleWrapper;
        }

        private void Print(double num)
        {
            consoleWrapper.Write($"=> { num }");
        }

        public void Add()
        {
            double[] input = inputHandler.ReadNumbers<double>(-1);

            if (input.Length == 2)
                Print(operations.Add(input[0], input[1]));
            else
                Print(operations.Add(input));
        }

        public void Subtract()
        {
            double[] input = inputHandler.ReadNumbers<double>(-1);

            if (input.Length == 2)
                Print(operations.Subtract(input[0], input[1]));
            else
                Print(operations.Subtract(input));
        }

        public void Divide()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Divide(input[0], input[1]));
        }

        public void Multiply()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Multiply(input[0], input[1]));
        }

        public void Modulo()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Modulo(input[0], input[1]));
        }

        public void Power()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Power(input[0], input[1]));
        }

        public void Root()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Root(input[0], input[1]));
        }

        public void Log()
        {
            double[] input = inputHandler.ReadNumbers<double>(2);
            Print(operations.Log(input[0], input[1]));
        }
    }
}
