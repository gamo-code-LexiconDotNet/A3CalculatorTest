using System;

namespace Calculator
{
    public class ConsoleWrapper : IConsoleWrapper
    {

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
