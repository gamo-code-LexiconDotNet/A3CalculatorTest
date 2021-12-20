using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Menu
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly Calculator _calculator;

        public Menu(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
            _calculator = new Calculator();
        }

        public void Run()
        {
            bool show = true;
            while (show)
                show = PrintMenu();
        }

        /**
         * Menu items
         */
        private readonly string[] menuItems =
        {
            "Add a to b (a + b)",                      //1
            "Divide a by b (a / b)",                   //2
            "Subtract b from a (a - b)",               //3
            "Multiply a with b (a * b)",               //4
            "Take to power of b to a (a ^ b)",         //5
            "Take the b root of a (a ^ (1 / b))",      //6
            "Take modulo b of a (a % b)",              //7
            "Take Log a with base b (Log(a) / Log(b)"  //8
        };

        /**
         * Menu
         */
        private bool PrintMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[Lexicon C#/.Net Programming] Assignment 3 - Calculator Test\n");
            sb.AppendLine("Choose what to calculate:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                sb.AppendLine($"{i + 1})  {menuItems[i]}");
            }
           sb.Append(
                "0)  Exit\n" +
                "> "
            );
            _consoleWrapper.Write(sb.ToString());

            string input = _consoleWrapper.ReadLine();
            _consoleWrapper.Clear();
            return input switch
            {
                "0" => false,
                "1" => HandleOperation(menuItems[0], _calculator.Add),
                "2" => HandleOperation(menuItems[1], _calculator.Divide),
                "3" => HandleOperation(menuItems[2], _calculator.Subtract),
                "4" => HandleOperation(menuItems[3], _calculator.Multiply),
                "5" => HandleOperation(menuItems[4], _calculator.Power),
                "6" => HandleOperation(menuItems[5], _calculator.Root),
                "7" => HandleOperation(menuItems[6], _calculator.Modulo),
                "8" => HandleOperation(menuItems[7], _calculator.Log),
                _ => true,
            };
        }

        /**
         * Handles the calls fom menu
         * Read input
         * Try math operation and write output
         * Handle exceptions
         */
        private bool HandleOperation(string message, Func<double, double, double> mathOperation)
        {
            _consoleWrapper.WriteLine(message);
            double a = ReadNumber<double>("Input a", "a must be a number");
            double b = ReadNumber<double>("Input b", "b must be a number");

            try
            {
                _consoleWrapper.WriteLine("=> " + Math.Round(mathOperation(a, b), 4).ToString());
            }
            catch (Exception ex)
            {
                if (ex is DivideByZeroException)
                    _consoleWrapper.WriteLine("Cannot divide by Zero.");
                else
                    _consoleWrapper.WriteLine(ex.ToString());
            }

            return HoldAndClear();
        }

        /**
         * Hold for key and clear console
         */
        private bool HoldAndClear(string message = "\n\tPress any key to continue...")
        {
            _consoleWrapper.Write(message);
            _consoleWrapper.ReadKey();
            _consoleWrapper.Clear();
            return true;
        }

        /**
         * Read number from input
         * Templated for different types
         * Asks for new input if input of wrong type (convert fails)
         */
        private T ReadNumber<T>(
            string message = "Input a number",
            string error = "You must input a number",
            int attempts = 100)
        {
            _consoleWrapper.Write($"{message}\n> ");
            while (attempts > 0)
                try
                {
                    return (T)ConvertStringToNumber<T>(_consoleWrapper.ReadLine());
                }
                catch
                {
                    _consoleWrapper.Write($"{error}\n> ");
                    attempts--;
                }

            throw new Exception("Could not read number from input");
        }

        private T ConvertStringToNumber<T>(string str)
        {
            TypeConverter converter;
            try
            {
                converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } // class
} // namespace
