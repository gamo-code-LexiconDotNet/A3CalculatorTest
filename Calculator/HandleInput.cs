using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Calculator
{
    public class HandleInput : IHandleInput
    {
        private readonly IConsoleWrapper consoleWrapper;

        public HandleInput(IConsoleWrapper consoleWrapper)
        {
            this.consoleWrapper = consoleWrapper;
        }

        public T[] ReadNumbers<T>(int numbersToRead = 1)
        {
            List<T> numbers = new List<T>();
            string pluralize = "";
            string numbersLeftToRead = "";
            string endInput = "";

            bool run = true;
            while (run)
            {
                if (numbersToRead - numbers.Count >= 2 || numbersToRead < 0)
                    pluralize = "s";
                else
                    pluralize = "";

                if (numbersToRead < 0)
                {
                    numbersLeftToRead = "";
                    endInput = " (end with \";\")";
                }
                else
                {
                    numbersLeftToRead = " " + (numbersToRead - numbers.Count).ToString();
                    endInput = "";
                }

                consoleWrapper.Write("Input{0} number{1}{2}: ",
                    numbersLeftToRead, pluralize, endInput);

                string[] inputs = HandleNumberString(
                    consoleWrapper.ReadLine())
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in inputs)
                {
                    if (s.Equals(";"))
                    {
                        run = false;
                        break;
                    }

                    if (numbersToRead >= 0
                        && numbers.Count >= numbersToRead)
                    {
                        run = false;
                        break;
                    }

                    try
                    {
                        numbers.Add(ConvertStringToNumber<T>(s));
                    }
                    catch (Exception ex)
                    {
                        consoleWrapper.WriteLine(ex.Message);
                        run = false;
                        break;
                    }
                }

                if (numbersToRead >= 0 && numbers.Count >= numbersToRead)
                {
                    run = false;
                    break;
                }
            }

            return numbers.ToArray<T>();
        }

        private string HandleNumberString(string numbers)
        {
            StringBuilder sb = new StringBuilder(numbers);

            string valid = " .0123456789-;";
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == ',')
                    sb[i] = ' ';
                else if (!valid.Contains(sb[i]))
                    sb[i] = ' ';

                if (sb[i] == '-' && i < sb.Length - 1 && sb[i + 1] == ' ')
                    sb[i] = ' ';

                if (sb[i] == ';')
                {
                    sb.Remove(i, sb.Length - i);
                    sb.Append(" ;");
                    break;
                }
            }

            return sb.ToString();
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
    }
}
